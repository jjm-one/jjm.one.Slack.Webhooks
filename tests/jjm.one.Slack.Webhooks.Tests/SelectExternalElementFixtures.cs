using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class SelectExternalElementFixtures
{
    [Fact]
    public void ShouldSerializeMinQueryLength()
    {
        // arrange
        var select = new SelectExternal
        {
            ActionId = "action_1",
            MinQueryLength = 5,
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"min_query_length\":5");
    }

    [Fact]
    public void ShouldSerializeInitialOption()
    {
        // arrange
        var option = new Option
        {
            Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText },
            Value = "Value123"
        };
        var select = new SelectExternal
        {
            ActionId = "action_2",
            InitialOption = option,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_option\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new SelectExternal
        {
            ActionId = "action_3",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"action_3\"");
    }

    [Fact]
    public void ShouldSerializePlaceholder()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Select an option",
            Type = TextObject.TextType.PlainText
        };
        var select = new SelectExternal
        {
            ActionId = "action_4",
            Placeholder = text,
            Type = ElementType.Unknown
        };

        // act
        var textPayload = SlackClient.SerializeObject(text);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"placeholder\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeConfirm()
    {
        // arrange
        var confirm = new Confirmation
        {
            Title = "Confirm Title",
            Text = "Are you sure?",
            OkText = "Yes",
            DismissText = "No",
            Confirm = null,
            Deny = null
        };
        var select = new SelectExternal
        {
            ActionId = "action_5",
            Confirm = confirm,
            Type = ElementType.Unknown
        };

        // act
        var confirmPayload = SlackClient.SerializeObject(confirm);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"confirm\":{confirmPayload}");
    }
}
