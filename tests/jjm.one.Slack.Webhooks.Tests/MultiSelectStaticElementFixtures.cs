using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class MultiSelectStaticElementFixtures
{
    [Fact]
    public void ShouldSerializeOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = "Option 1", Value = "Value123" }
        };
        var select = new MultiSelectStatic
        {
            ActionId = "action_1",
            Options = options,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"options\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeInitialOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = "Option 1", Value = "Value123" }
        };
        var select = new MultiSelectStatic
        {
            ActionId = "action_2",
            InitialOptions = options,
            Options = null,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_options\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeOptionGroups()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = "Option 1", Value = "Value123" }
        };
        var groups = new List<OptionGroup>
        {
            new()
            {
                Text = "Group 1",
                Options = options,
                Label = null
            }
        };
        var select = new MultiSelectStatic
        {
            ActionId = "action_3",
            OptionGroups = groups,
            Options = null,
            Type = ElementType.Unknown
        };

        // act
        var groupsPayload = SlackClient.SerializeObject(groups);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"option_groups\":{groupsPayload}");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new MultiSelectStatic
        {
            ActionId = "action_4",
            Options = new List<Option>
            {
                new()
                {
                    Text = "Option 1",
                    Value = "Value123"
                }
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"action_4\"");
    }
}
