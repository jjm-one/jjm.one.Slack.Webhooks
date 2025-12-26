using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class MultiSelectExternalElementFixtures
{
    [Fact]
    public void ShouldSerializeMinQueryLength()
    {
        // arrange
        var select = new MultiSelectExternal
        {
            ActionId = "action_1",
            MinQueryLength = 5,
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"min_query_length\":5");
    }

    [Fact]
    public void ShouldSerializeInitialOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = "Option 1", Value = "Value123" }
        };
        var select = new MultiSelectExternal
        {
            ActionId = "action_2",
            InitialOptions = options,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_options\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new MultiSelectExternal
        {
            ActionId = "action_3",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"action_3\"");
    }
}
