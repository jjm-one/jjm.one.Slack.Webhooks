using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;
using jjm.one.Slack.Webhooks.Interfaces;

namespace jjm.one.Slack.Webhooks.Tests;

public class InputBlockFixtures
{
    [Fact]
    public void ShouldSerializeLabel()
    {
        // arrange
        var textObject = new TextObject
        {
            Text = "Test label",
            Type = TextObject.TextType.PlainText
        };
        var input = new Input
        {
            BlockId = "input_block_1",
            Label = textObject,
            Element = new PlainTextInput
            {
                ActionId = "action_1",
                Type = ElementType.Unknown
            }
        };

        // act
        var textPayload = SlackClient.SerializeObject(textObject);
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain($"\"label\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeHint()
    {
        // arrange
        var textObject = new TextObject
        {
            Text = "Test hint",
            Type = TextObject.TextType.PlainText
        };
        var input = new Input
        {
            BlockId = "input_block_2",
            Label = new TextObject
            {
                Text = "Label",
                Type = TextObject.TextType.PlainText
            },
            Hint = textObject,
            Element = new PlainTextInput
            {
                ActionId = "action_2",
                Type = ElementType.Unknown
            }
        };

        // act
        var textPayload = SlackClient.SerializeObject(textObject);
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain($"\"hint\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeOptional()
    {
        // arrange
        var input = new Input
        {
            BlockId = "input_block_3",
            Label = new TextObject
            {
                Text = "Label",
                Type = TextObject.TextType.PlainText
            },
            Optional = true,
            Element = new PlainTextInput
            {
                ActionId = "action_3",
                Type = ElementType.Unknown
            }
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"optional\":true");
    }

    [Theory]
    [MemberData(nameof(GetInputElementData))]
    public void ShouldSerializeInputElementTypes(IInputElement element)
    {
        // arrange
        var input = new Input
        {
            BlockId = "input_block_4",
            Label = new TextObject
            {
                Text = "Label",
                Type = TextObject.TextType.PlainText
            },
            Element = element
        };

        // act
        var elementPayload = SlackClient.SerializeObject(element);
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain($"\"element\":{elementPayload}");
    }

    public static IEnumerable<object[]> GetInputElementData()
    {
        return new List<object[]>
        {
            new object[] { new PlainTextInput
                {
                    ActionId = "action_plain_text",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new SelectChannels
                {
                    ActionId = "action_channels",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new SelectUsers
                {
                    ActionId = "action_users",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new SelectConversations
                {
                    ActionId = "action_conversations",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new SelectStatic
                {
                    ActionId = "action_static",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Option 1",
                            Value = "value_1"
                        }
                    },
                    Type = ElementType.Unknown
                }
            },
            new object[] { new SelectExternal
                {
                    ActionId = "action_external",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new MultiSelectChannels
                {
                    ActionId = "action_multi_channels",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new MultiSelectUsers
                {
                    ActionId = "action_multi_users",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new MultiSelectConversations
                {
                    ActionId = "action_multi_conversations",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new MultiSelectStatic
                {
                    ActionId = "action_multi_static",
                    Options = new List<Option>
                    {
                        new Option
                        {
                            Text = "Option 1",
                            Value = "value_1"
                        }
                    },
                    Type = ElementType.Unknown
                }
            },
            new object[] { new MultiSelectExternal
                {
                    ActionId = "action_multi_external",
                    Type = ElementType.Unknown
                }
            },
            new object[] { new DatePicker
                {
                    ActionId = "action_datepicker",
                    Type = ElementType.Unknown
                }
            }
        };
    }
}
