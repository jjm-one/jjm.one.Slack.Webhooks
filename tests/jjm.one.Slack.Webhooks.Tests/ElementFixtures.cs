using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class ElementFixtures
{
    [Theory]
    [MemberData(nameof(GetData))]
    public void ShouldHaveElementType(Element element, string expectedType)
    {
        // arrange/act
        var payload = SlackClient.SerializeObject(element);

        // assert
        payload.Should().Contain($"\"type\":\"{expectedType}\"");
    }

    public static IEnumerable<object[]> GetData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new Button
                {
                    ActionId = "button_1",
                    Text = new TextObject
                    {
                        Type = TextObject.TextType.PlainText,
                        Text = "Click Me"
                    },
                    Type = ElementType.Unknown
                },
                "button"
            },
            new object[]
            {
                new DatePicker
                {
                    ActionId = "datepicker_1",
                    Type = ElementType.Unknown
                },
                "datepicker"
            },
            new object[]
            {
                new Image
                {
                    ImageUrl = "https://example.com/image.png",
                    AltText = "Example Image",
                    Type = ElementType.Unknown
                },
                "image"
            },
            new object[]
            {
                new MultiSelectChannels
                {
                    ActionId = "multi_channels_1",
                    Type = ElementType.Unknown
                },
                "multi_channels_select"
            },
            new object[]
            {
                new MultiSelectConversations
                {
                    ActionId = "multi_conversations_1",
                    Type = ElementType.Unknown
                },
                "multi_conversations_select"
            },
            new object[]
            {
                new MultiSelectExternal
                {
                    ActionId = "multi_external_1",
                    Type = ElementType.Unknown
                },
                "multi_external_select"
            },
            new object[]
            {
                new MultiSelectStatic
                {
                    ActionId = "multi_static_1",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Option 1",
                            Value = "value_1"
                        },
                        new Option
                        {
                            Text = "Option 2",
                            Value = "value_2"
                        }
                    },
                    Type = ElementType.Unknown
                },
                "multi_static_select"
            },
            new object[]
            {
                new MultiSelectUsers
                {
                    ActionId = "multi_users_1",
                    Type = ElementType.Unknown
                },
                "multi_users_select"
            },
            new object[]
            {
                new Overflow
                {
                    ActionId = "overflow_1",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Overflow Option 1",
                            Value = "overflow_value_1"
                        },
                        new Option
                        {
                            Text = "Overflow Option 2",
                            Value = "overflow_value_2"
                        }
                    },
                    Type = ElementType.Unknown
                },
                "overflow"
            },
            new object[]
            {
                new PlainTextInput
                {
                    ActionId = "plain_text_input_1",
                    Type = ElementType.Unknown
                },
                "plain_text_input"
            },
            new object[]
            {
                new RadioButtons
                {
                    ActionId = "radio_buttons_1",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Option 1",
                            Value = "value_1"
                        },
                        new Option
                        {
                            Text = "Option 2",
                            Value = "value_2"
                        }
                    },
                    Type = ElementType.Unknown
                },
                "radio_buttons"
            },
            new object[]
            {
                new SelectChannels
                {
                    ActionId = "channels_select_1",
                    Type = ElementType.Unknown
                },
                "channels_select"
            },
            new object[]
            {
                new SelectConversations
                {
                    ActionId = "conversations_select_1",
                    Type = ElementType.Unknown
                },
                "conversations_select"
            },
            new object[]
            {
                new SelectExternal
                {
                    ActionId = "external_select_1",
                    Type = ElementType.Unknown
                },
                "external_select"
            },
            new object[]
            {
                new SelectStatic
                {
                    ActionId = "static_select_1",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Option 1",
                            Value = "value_1"
                        },
                        new Option
                        {
                            Text = "Option 2",
                            Value = "value_2"
                        }
                    },
                    Type = ElementType.Unknown
                },
                "static_select"
            },
            new object[]
            {
                new SelectUsers
                {
                    ActionId = "users_select_1",
                    Type = ElementType.Unknown
                },
                "users_select"
            }
        };
    }
}
