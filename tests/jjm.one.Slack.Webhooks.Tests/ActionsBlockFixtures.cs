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
            new Button(),
            new SelectChannels(),
            new SelectConversations(),
            new SelectExternal(),
            new SelectStatic(),
            new SelectUsers(),
            new Overflow(),
            new DatePicker()
        };
        var actions = new Actions { Elements = elementList };

        // act
        var elementListPayload = SlackClient.SerializeObject(elementList);
        var payload = SlackClient.SerializeObject(actions);

        // assert
        payload.Should().Contain($"\"elements\":{elementListPayload}");
    }
}