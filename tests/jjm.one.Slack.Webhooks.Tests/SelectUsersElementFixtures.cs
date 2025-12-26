using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class SelectUsersElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialUser()
    {
        // arrange
        var option = "User321";
        var select = new SelectUsers
        {
            ActionId = "action_1",
            InitialUser = option,
            Type = ElementType.Unknown
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_user\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var select = new SelectUsers
        {
            ActionId = "action_2",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain("\"action_id\":\"action_2\"");
    }

    [Fact]
    public void ShouldSerializePlaceholder()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Select a user",
            Type = TextObject.TextType.PlainText
        };
        var select = new SelectUsers
        {
            ActionId = "action_3",
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
        var select = new SelectUsers
        {
            ActionId = "action_4",
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

public class SelectConversationsElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialConversation()
    {
        // arrange
        var option = "Convo321";
        var select = new SelectConversations
        {
            InitialConversation = option,
            Type = ElementType.Unknown,
            ActionId = null
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_conversation\":{optionsPayload}");
    }
}

public class SelectChannelsElementFixtures
{
    [Fact]
    public void ShouldSerializeInitialChannel()
    {
        // arrange
        var option = "Convo321";
        var select = new SelectChannels
        {
            InitialChannel = option,
            Type = ElementType.Unknown,
            ActionId = null
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(option);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_channel\":{optionsPayload}");
    }
}
