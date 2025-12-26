using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class PlainTextInputElementFixtures
{
    [Fact]
    public void ShouldSerializeType()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "action_1",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"type\":\"plain_text_input\"");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "Action123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"action_id\":\"Action123\"");
    }

    [Fact]
    public void ShouldSerializePlaceholder()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Enter text",
            Type = TextObject.TextType.PlainText
        };
        var input = new PlainTextInput
        {
            ActionId = "action_2",
            Placeholder = text,
            Type = ElementType.Unknown
        };

        // act
        var textPayload = SlackClient.SerializeObject(text);
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain($"\"placeholder\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeInitialValue()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "action_3",
            InitialValue = "Value123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"initial_value\":\"Value123\"");
    }

    [Fact]
    public void ShouldSerializeMultiLine()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "action_4",
            MultiLine = true,
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"multi_line\":true");
    }

    [Fact]
    public void ShouldSerializeMinLength()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "action_5",
            MinLength = 10,
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"min_length\":10");
    }

    [Fact]
    public void ShouldSerializeMaxLength()
    {
        // arrange
        var input = new PlainTextInput
        {
            ActionId = "action_6",
            MaxLength = 20,
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(input);

        // assert
        payload.Should().Contain("\"max_length\":20");
    }
}
