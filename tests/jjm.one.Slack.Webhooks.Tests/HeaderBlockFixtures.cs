using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class HeaderBlockFixtures
{
    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var textObject = new TextObject
        {
            Text = "This is text",
            Type = TextObject.TextType.PlainText
        };
        var header = new Header
        {
            BlockId = "header_block_1",
            Text = textObject
        };

        // act
        var textPayload = SlackClient.SerializeObject(textObject);
        var payload = SlackClient.SerializeObject(header);

        // assert
        payload.Should().Contain($"\"text\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeBlockId()
    {
        // arrange
        var header = new Header
        {
            BlockId = "header_block_2",
            Text = new TextObject
            {
                Text = "Header Text",
                Type = TextObject.TextType.PlainText
            }
        };

        // act
        var payload = SlackClient.SerializeObject(header);

        // assert
        payload.Should().Contain("\"block_id\":\"header_block_2\"");
    }
}
