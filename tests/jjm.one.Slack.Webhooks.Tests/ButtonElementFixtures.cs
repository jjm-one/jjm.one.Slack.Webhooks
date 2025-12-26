using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class ButtonElementFixtures
{
    [Fact]
    public void ShouldSerializeType()
    {
        // arrange
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"type\":\"button\"");
    }

    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Test Text"
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"text\":{\"type\":\"plain_text\",\"text\":\"Test Text\"");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var button = new Button
        {
            ActionId = "Action123",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"action_id\":\"Action123\"");
    }

    [Fact]
    public void ShouldSerializeUrl()
    {
        // arrange
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Url = "http://someurl.com",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"url\":\"http://someurl.com\"");
    }

    [Fact]
    public void ShouldSerializeValue()
    {
        // arrange
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Value = "Value123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"value\":\"Value123\"");
    }

    [Fact]
    public void ShouldSerializeStyle()
    {
        // arrange
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Style = "Style123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain("\"style\":\"Style123\"");
    }

    [Fact]
    public void ShouldSerializeConfirm()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = new TextObject { Text = "Confirm Title", Type = TextObject.TextType.PlainText },
            Text = new TextObject { Text = "Are you sure?", Type = TextObject.TextType.PlainText },
            Confirm = new TextObject { Text = "Yes", Type = TextObject.TextType.PlainText },
            Deny = new TextObject { Text = "No", Type = TextObject.TextType.PlainText }
        };
        var button = new Button
        {
            ActionId = "action_1",
            Text = new TextObject
            {
                Type = TextObject.TextType.PlainText,
                Text = "Click Me"
            },
            Confirm = confirm,
            Type = ElementType.Unknown
        };

        // act
        var confirmPayload = SlackClient.SerializeObject(confirm);
        var payload = SlackClient.SerializeObject(button);

        // assert
        payload.Should().Contain($"\"confirm\":{confirmPayload}");
    }
}
