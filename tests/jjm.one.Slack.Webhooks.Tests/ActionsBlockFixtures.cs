using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;
using jjm.one.Slack.Webhooks.Interfaces;

namespace jjm.one.Slack.Webhooks.Tests;

public class ActionsBlockFixtures
{
    [Fact]
    public void ShouldSerializeActionElements()
    {
        // arrange
        var elementList = new List<IActionElement>
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
            new SelectChannels
            {
                ActionId = "select_channels_1",
                Type = ElementType.Unknown
            },
            new SelectConversations
            {
                ActionId = "select_conversations_1",
                Type = ElementType.Unknown
            },
            new SelectExternal
            {
                ActionId = "select_external_1",
                Type = ElementType.Unknown
            },
            new SelectStatic
            {
                ActionId = "select_static_1",
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
            new SelectUsers
            {
                ActionId = "select_users_1",
                Type = ElementType.Unknown
            },
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
            new DatePicker
            {
                ActionId = "datepicker_1",
                Type = ElementType.Unknown
            }
        };
        var actions = new Actions
        {
            Elements = elementList,
            BlockId = null
        };

        // act
        var elementListPayload = SlackClient.SerializeObject(elementList);
        var payload = SlackClient.SerializeObject(actions);

        // assert
        payload.Should().Contain($"\"elements\":{elementListPayload}");
    }
}
