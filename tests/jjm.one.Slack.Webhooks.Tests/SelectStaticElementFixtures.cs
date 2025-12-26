using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class SelectStaticElementFixtures
{
    [Fact]
    public void ShouldSerializeOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText }, Value = "Value123" }
        };
        var select = new SelectStatic
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
    public void ShouldSerializeInitialOption()
    {
        // arrange
        var option = new Option
        {
            Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText },
            Value = "Value123"
        };
        var select = new SelectStatic
        {
            ActionId = "action_2",
            InitialOption = option,
            Options = null,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_option\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeOptionGroups()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText }, Value = "Value123" }
        };
        var groups = new List<OptionGroup>
        {
            new() { Label = new TextObject { Text = "Group 1", Type = TextObject.TextType.PlainText }, Options = options }
        };
        var select = new SelectStatic
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
        var select = new SelectStatic
        {
            ActionId = "action_4",
            Options = new List<Option>
            {
                new()
                {
                    Text = new TextObject
                    {
                        Text = "Option 1",
                        Type = TextObject.TextType.PlainText
                    },
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

    [Fact]
    public void ShouldSerializePlaceholder()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Select an option",
            Type = TextObject.TextType.PlainText
        };
        var select = new SelectStatic
        {
            ActionId = "action_5",
            Placeholder = text,
            Options = null,
            Type = ElementType.Unknown
        };

        // act
        var textPayload = SlackClient.SerializeObject(text);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"placeholder\":{textPayload}");
    }
}
