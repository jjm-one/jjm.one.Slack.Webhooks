using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class ElementFixtures
{
    [Theory]
    [MemberData(nameof(GetData))]
    public void ShouldHaveBlockTypeAndBlockId(Element element, string expectedType)
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
            new object[] { new Button(), "button" },
            new object[] { new DatePicker(), "datepicker" },
            new object[] { new Image(), "image" },
            new object[] { new MultiSelectChannels(), "multi_channels_select" },
            new object[] { new MultiSelectConversations(), "multi_conversations_select" },
            new object[] { new MultiSelectExternal(), "multi_external_select" },
            new object[] { new MultiSelectStatic(), "multi_static_select" },
            new object[] { new MultiSelectUsers(), "multi_users_select" },
            new object[] { new Overflow(), "overflow" },
            new object[] { new PlainTextInput(), "plain_text_input" },
            new object[] { new RadioButtons(), "radio_buttons" },
            new object[] { new SelectChannels(), "channels_select" },
            new object[] { new SelectConversations(), "conversations_select" },
            new object[] { new SelectExternal(), "external_select" },
            new object[] { new SelectStatic(), "static_select" },
            new object[] { new SelectUsers(), "users_select" }
        };
    }
}