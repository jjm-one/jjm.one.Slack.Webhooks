using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class SelectElementFixtures
{
    [Theory]
    [InlineData(ElementType.MultiSelectStatic, "multi_static_select")]
    [InlineData(ElementType.MultiSelectExternal, "multi_external_select")]
    [InlineData(ElementType.MultiSelectUsers, "multi_users_select")]
    [InlineData(ElementType.MultiSelectConversations, "multi_conversations_select")]
    [InlineData(ElementType.MultiSelectChannels, "multi_channels_select")]
    [InlineData(ElementType.SelectStatic, "static_select")]
    [InlineData(ElementType.SelectExternal, "external_select")]
    [InlineData(ElementType.SelectUsers, "users_select")]
    [InlineData(ElementType.SelectConversations, "conversations_select")]
    [InlineData(ElementType.SelectChannels, "channels_select")]
    public void ShouldSerializeType(ElementType elementType, string expected)
    {
        // arrange
        var select = new Select(elementType)
        {
            ActionId = "action_1",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"type\":\"{expected}\"");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new Select(ElementType.MultiSelectStatic)
        {
            ActionId = "Action123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"Action123\"");
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
        var select = new Select(ElementType.MultiSelectStatic)
        {
            ActionId = "action_2",
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
        var select = new Select(ElementType.MultiSelectStatic)
        {
            ActionId = "action_3",
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
