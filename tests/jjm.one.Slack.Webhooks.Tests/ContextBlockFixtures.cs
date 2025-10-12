using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;
using jjm.one.Slack.Webhooks.Interfaces;
using Image = jjm.one.Slack.Webhooks.Blocks.Image;

namespace jjm.one.Slack.Webhooks.Tests;

public class ContextBlockFixtures
{
    [Fact]
    public void ShouldBeAbleToContainImageElements()
    {
        // arrange
        var context = new Context
        {
            Elements = new List<IContextElement> { new Image() }
        };

        // act
        var payload = SlackClient.SerializeObject(context);

        // assert
        payload.Should().Contain("\"elements\":["); // bleeugh
    }

    [Fact]
    public void ShouldBeAbleToContainTextElements()
    {
        // arrange
        var context = new Context
        {
            Elements = new List<IContextElement> { new TextObject() }
        };

        // act
        var payload = SlackClient.SerializeObject(context);

        // assert
        payload.Should().Contain("\"elements\":["); // bleeugh
    }
}