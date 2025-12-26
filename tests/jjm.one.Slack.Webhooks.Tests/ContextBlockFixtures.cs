using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;
using jjm.one.Slack.Webhooks.Interfaces;

namespace jjm.one.Slack.Webhooks.Tests;

public class ContextBlockFixtures
{
    [Fact]
    public void ShouldBeAbleToContainImageElements()
    {
        // arrange
        var context = new Context
        {
            BlockId = "context_1",
            Elements = new List<IContextElement>
            {
                new Blocks.Image
                {
                    ImageUrl = "https://example.com/image.png",
                    AltText = "Example Image",
                    BlockId = null
                }
            }
        };

        // act
        var payload = SlackClient.SerializeObject(context);

        // assert
        payload.Should().Contain("\"elements\":[");
        payload.Should().Contain("\"type\":\"image\"");
        payload.Should().Contain("\"image_url\":\"https://example.com/image.png\"");
        payload.Should().Contain("\"alt_text\":\"Example Image\"");
    }

    [Fact]
    public void ShouldBeAbleToContainTextElements()
    {
        // arrange
        var context = new Context
        {
            BlockId = "context_2",
            Elements = new List<IContextElement>
            {
                new TextObject
                {
                    Type = TextObject.TextType.PlainText,
                    Text = "Example Text"
                }
            }
        };

        // act
        var payload = SlackClient.SerializeObject(context);

        // assert
        payload.Should().Contain("\"elements\":[");
        payload.Should().Contain("\"type\":\"plain_text\"");
        payload.Should().Contain("\"text\":\"Example Text\"");
    }
}
