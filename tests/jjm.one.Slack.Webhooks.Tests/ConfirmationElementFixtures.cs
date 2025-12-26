using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class ConfirmationElementFixtures
{
    [Fact]
    public void ShouldSerializeTitle()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = new TextObject { Text = "Confirm Title", Type = TextObject.TextType.PlainText },
            Text = new TextObject { Text = "Are you sure?", Type = TextObject.TextType.PlainText },
            Confirm = new TextObject { Text = "Yes", Type = TextObject.TextType.PlainText },
            Deny = new TextObject { Text = "No", Type = TextObject.TextType.PlainText }
        };

        // act
        var payload = SlackClient.SerializeObject(confirm);

        // assert
        payload.Should().Contain("\"title\":\"Confirm Title\"");
    }

    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = new TextObject { Text = "Confirm Title", Type = TextObject.TextType.PlainText },
            Text = new TextObject { Text = "Are you sure?", Type = TextObject.TextType.PlainText },
            Confirm = new TextObject { Text = "Yes", Type = TextObject.TextType.PlainText },
            Deny = new TextObject { Text = "No", Type = TextObject.TextType.PlainText }
        };

        // act
        var payload = SlackClient.SerializeObject(confirm);

        // assert
        payload.Should().Contain("\"text\":\"Are you sure?\"");
    }

    [Fact]
    public void ShouldSerializeOkText()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = new TextObject { Text = "Confirm Title", Type = TextObject.TextType.PlainText },
            Text = new TextObject { Text = "Are you sure?", Type = TextObject.TextType.PlainText },
            Confirm = new TextObject { Text = "Yes", Type = TextObject.TextType.PlainText },
            Deny = new TextObject { Text = "No", Type = TextObject.TextType.PlainText }
        };

        // act
        var payload = SlackClient.SerializeObject(confirm);

        // assert
        payload.Should().Contain("\"ok_text\":\"Yes\"");
    }

    [Fact]
    public void ShouldSerializeDismissText()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = new TextObject { Text = "Confirm Title", Type = TextObject.TextType.PlainText },
            Text = new TextObject { Text = "Are you sure?", Type = TextObject.TextType.PlainText },
            Confirm = new TextObject { Text = "Yes", Type = TextObject.TextType.PlainText },
            Deny = new TextObject { Text = "No", Type = TextObject.TextType.PlainText }
        };

        // act
        var payload = SlackClient.SerializeObject(confirm);

        // assert
        payload.Should().Contain("\"dismiss_text\":\"No\"");
    }
}
