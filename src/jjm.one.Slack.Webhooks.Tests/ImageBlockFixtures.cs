using jjm.one.Slack.Webhooks.Elements;
using Image = jjm.one.Slack.Webhooks.Blocks.Image;

namespace jjm.one.Slack.Webhooks.Tests;

public class ImageBlockFixtures
{
    [Fact]
    public void ShouldContainImageUrl()
    {
        // arrange
        var image = new Image { ImageUrl = "http://someimage" };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"image_url\":\"http://someimage\"");
    }

    [Fact]
    public void ShouldContainAltText()
    {
        // arrange
        var image = new Image { AltText = "The Text" };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"alt_text\":\"The Text\"");
    }

    [Fact]
    public void ShouldContainTitle()
    {
        // arrange
        var image = new Image { Title = new TextObject { Text = "The Title" } };

        // act
        var payload = SlackClient.SerializeObject(image);

        // assert
        payload.Should().Contain("\"text\":\"The Title\"");
    }
}