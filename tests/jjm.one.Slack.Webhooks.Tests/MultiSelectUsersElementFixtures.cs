using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class MultiSelectUsersElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialUsers()
    {
        // arrange
        var options = new List<string> { "User123", "User321" };
        var select = new MultiSelectUsers
        {
            ActionId = "action_1",
            InitialUsers = options,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_users\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new MultiSelectUsers
        {
            ActionId = "action_2",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"action_2\"");
    }
}

public class MultiSelectConversationsElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialConversations()
    {
        // arrange
        var options = new List<string> { "Convo123", "Convo321" };
        var select = new MultiSelectConversations
        {
            InitialConversations = options,
            Type = ElementType.Unknown,
            ActionId = null
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_conversations\":{optionsPayload}");
    }
}

public class MultiSelectChannelsElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialChannels()
    {
        // arrange
        var options = new List<string> { "Convo123", "Convo321" };
        var select = new MultiSelectChannels
        {
            InitialChannels = options,
            Type = ElementType.Unknown,
            ActionId = null
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_channels\":{optionsPayload}");
    }
}
