using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace jjm.one.Slack.Webhooks;

public class SlackClient : ISlackClient, IDisposable
{
    private const string POST_SUCCESS = "ok";

    private static readonly DefaultContractResolver resolver = new() { NamingStrategy = new SnakeCaseNamingStrategy() };

    private static readonly JsonSerializerSettings? serializerSettings = new()
    {
        ContractResolver = resolver,
        NullValueHandling = NullValueHandling.Ignore
    };

    private readonly HttpClient _httpClient;
    private readonly Uri? _webhookUri;
    private readonly int _timeout = 100;

    public SlackClient(string webhookUrl, int timeout = 100, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
            throw new ArgumentException("Please enter a valid webhook url");
        _timeout = timeout;
    }

    /// <summary>
    ///     Returns the current Timeout value.
    /// </summary>
    public int TimeoutMs => _timeout * 1000;

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public virtual bool Post(SlackMessage slackMessage)
    {
        return PostAsync(slackMessage, false).Result;
    }

    public bool PostToChannels(SlackMessage message, IEnumerable<string> channels)
    {
        return channels.DefaultIfEmpty(message.Channel)
            .Select(message.Clone)
            .Select(Post).All(r => r);
    }

    public IEnumerable<Task<bool>> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels)
    {
        return channels.DefaultIfEmpty(message.Channel)
            .Select(message.Clone)
            .Select(PostAsync);
    }

    public async Task<bool> PostAsync(SlackMessage slackMessage)
    {
        return await PostAsync(slackMessage, true);
    }

    public async Task<bool> PostAsync(SlackMessage slackMessage, bool configureAwait = true)
    {
        using (var request = new HttpRequestMessage(HttpMethod.Post, _webhookUri))
        {
            request.Content = new StringContent(slackMessage.AsJson(), Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(request).ConfigureAwait(configureAwait);
            var content = await response.Content.ReadAsStringAsync();
            return content.Equals(POST_SUCCESS, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    ///     Deserialize SlackMessage from a JSON string
    /// </summary>
    /// <param name="json">string containing serialized JSON</param>
    /// <returns>SlackMessage</returns>
    public static SlackMessage? DeserializeObject(string json)
    {
        return JsonConvert.DeserializeObject<SlackMessage>(json, serializerSettings);
    }

    /// <summary>
    ///     Serialize SlackMessage to a JSON string
    /// </summary>
    /// <param name="json">An instance of SlackMessage</param>
    /// <returns>string containing serialized JSON</returns>
    public static string SerializeObject(object obj)
    {
        return JsonConvert.SerializeObject(obj, serializerSettings);
    }
}