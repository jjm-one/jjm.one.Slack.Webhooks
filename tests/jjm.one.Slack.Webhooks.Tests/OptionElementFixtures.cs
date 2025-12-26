using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class OptionElementFixtures
{
    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Option Text",
            Type = TextObject.TextType.PlainText
        };
        var option = new Option
        {
            Text = text,
            Value = "Value123"
        };

        // act
        var textPayload = SlackClient.SerializeObject(text);
        var payload = SlackClient.SerializeObject(option);

        // assert
        payload.Should().Contain($"\"text\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeValue()
    {
        // arrange
        var option = new Option
        {
            Text = new TextObject
            {
                Text = "Option Text",
                Type = TextObject.TextType.PlainText
            },
            Value = "Value123"
        };

        // act
        var payload = SlackClient.SerializeObject(option);

        // assert
        payload.Should().Contain("\"value\":\"Value123\"");
    }

    [Fact]
    public void ShouldSerializeUrl()
    {
        // arrange
        var option = new Option
        {
            Text = new TextObject
            {
                Text = "Option Text",
                Type = TextObject.TextType.PlainText
            },
            Value = "Value123",
            Url = "http://someurl.com"
        };

        // act
        var payload = SlackClient.SerializeObject(option);

        // assert
        payload.Should().Contain("\"url\":\"http://someurl.com\"");
    }
}
