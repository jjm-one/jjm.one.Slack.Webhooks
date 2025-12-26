using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class RadioButtonElementFixtures
{
    [Fact]
    public void ShouldSerializeType()
    {
        // arrange
        var radio = new RadioButtons
        {
            ActionId = "action_1",
            Options = new List<Option>
            {
                new()
                {
                    Text = new TextObject
                    {
                        Text = "Option 1",
                        Type = TextObject.TextType.PlainText
                    },
                    Value = "value_1"
                }
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(radio);

        // assert
        payload.Should().Contain("\"type\":\"radio_buttons\"");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var radio = new RadioButtons
        {
            ActionId = "Action123",
            Options = new List<Option>
            {
                new()
                {
                    Text = new TextObject
                    {
                        Text = "Option 1",
                        Type = TextObject.TextType.PlainText
                    },
                    Value = "value_1"
                }
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(radio);

        // assert
        payload.Should().Contain("\"action_id\":\"Action123\"");
    }

    [Fact]
    public void ShouldSerializeConfirm()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = "Confirm Title",
            Text = "Are you sure?",
            OkText = "Yes",
            DismissText = "No",
            Confirm = null,
            Deny = null
        };
        var radio = new RadioButtons
        {
            ActionId = "action_2",
            Confirm = confirm,
            Options = new List<Option>
            {
                new()
                {
                    Text = new TextObject
                    {
                        Text = "Option 1",
                        Type = TextObject.TextType.PlainText
                    },
                    Value = "value_1"
                }
            },
            Type = ElementType.Unknown
        };

        // act
        var confirmPayload = SlackClient.SerializeObject(confirm);
        var payload = SlackClient.SerializeObject(radio);

        // assert
        payload.Should().Contain($"\"confirm\":{confirmPayload}");
    }

    [Fact]
    public void ShouldSerializeOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText }, Value = "value_1" },
            new() { Text = new TextObject { Text = "Option 2", Type = TextObject.TextType.PlainText }, Value = "value_2" }
        };
        var radio = new RadioButtons
        {
            ActionId = "action_3",
            Options = options,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(radio);

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
            Value = "value_1"
        };
        var radio = new RadioButtons
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
                    Value = "value_1"
                }
            },
            InitialOption = option,
            Type = ElementType.Unknown
        };

        // act
        var optionPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(radio);

        // assert
        payload.Should().Contain($"\"initial_option\":{optionPayload}");
    }
}
