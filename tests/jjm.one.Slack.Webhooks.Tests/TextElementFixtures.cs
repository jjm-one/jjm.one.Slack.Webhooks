using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class TextElementFixtures
{
    [Theory]
    [InlineData(TextObject.TextType.Markdown, "mrkdwn")]
    [InlineData(TextObject.TextType.PlainText, "plain_text")]
    public void ShouldContainTextType(TextObject.TextType textType, string expected)
    {
        // arrange
        var text = new TextObject { Type = textType, Text = "Sample Text" };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().Contain($"\"type\":\"{expected}\"");
    }

    [Fact]
    public void ShouldNotContainEmojiWhenTextTypeIsMarkdown()
    {
        // arrange
        var text = new TextObject { Type = TextObject.TextType.Markdown, Text = "Sample Text" };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().NotContain("\"emoji\":");
    }

    [Fact]
    public void ShouldNotSerializeVerbatimWhenTextTypeIsPlainText()
    {
        // arrange
        var text = new TextObject { Type = TextObject.TextType.PlainText, Text = "Sample Text" };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().NotContain("\"verbatim\":");
    }

    [Fact]
    public void ShouldSerializeEmojiWhenTextTypeIsPlainText()
    {
        // arrange
        var text = new TextObject
        {
            Type = TextObject.TextType.PlainText,
            Text = "Sample Text",
            Emoji = true
        };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().Contain("\"emoji\":true");
    }

    [Fact]
    public void ShouldSerializeVerbatimWhenTextTypeIsMarkdown()
    {
        // arrange
        var text = new TextObject
        {
            Type = TextObject.TextType.Markdown,
            Text = "Sample Text",
            Verbatim = true
        };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().Contain("\"verbatim\":true");
    }

    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var text = new TextObject
        {
            Type = TextObject.TextType.PlainText,
            Text = "Sample Text"
        };

        // act
        var payload = SlackClient.SerializeObject(text);

        // assert
        payload.Should().Contain("\"text\":\"Sample Text\"");
    }
}
