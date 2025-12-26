using jjm.one.Slack.Webhooks.Elements;
using Image = jjm.one.Slack.Webhooks.Blocks.Image;

namespace jjm.one.Slack.Webhooks.Tests;

public class ImageBlockFixtures
{
    [Fact]
    public void ShouldContainImageUrl()
    {
        // arrange
        var image = new Image
        {
            BlockId = "image_block_1",
            ImageUrl = "http://someimage",
            AltText = "Alt Text"
        };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"image_url\":\"http://someimage\"");
    }

    [Fact]
    public void ShouldContainAltText()
    {
        // arrange
        var image = new Image
        {
            BlockId = "image_block_2",
            ImageUrl = "http://someimage",
            AltText = "The Text"
        };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"alt_text\":\"The Text\"");
    }

    [Fact]
    public void ShouldContainTitle()
    {
        // arrange
        var image = new Image
        {
            BlockId = "image_block_3",
            ImageUrl = "http://someimage",
            AltText = "Alt Text",
            Title = new TextObject
            {
                Text = "The Title",
                Type = TextObject.TextType.PlainText
            }
        };

        // act
        var titlePayload = SlackClient.SerializeObject(image.Title);
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain($"\"title\":{titlePayload}");
    }

    [Fact]
    public void ShouldSerializeBlockId()
    {
        // arrange
        var image = new Image
        {
            BlockId = "image_block_4",
            ImageUrl = "http://someimage",
            AltText = "Alt Text"
        };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"block_id\":\"image_block_4\"");
    }
}
