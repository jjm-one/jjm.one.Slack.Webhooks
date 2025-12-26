using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class DatePickerElementFixtures
{
    [Fact]
    public void ShouldSerializeType()
    {
        // arrange
        var datePicker = new DatePicker
        {
            ActionId = "action_1",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(datePicker);

        // assert
        payload.Should().Contain("\"type\":\"datepicker\"");
    }

    [Fact]
    public void ShouldSerializeActionId()
    {
        // arrange
        var datePicker = new DatePicker
        {
            ActionId = "Action123",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(datePicker);

        // assert
        payload.Should().Contain("\"action_id\":\"Action123\"");
    }

    [Fact]
    public void ShouldSerializeInitialDate()
    {
        // arrange
        var datePicker = new DatePicker
        {
            ActionId = "action_1",
            InitialDate = "2019-11-01",
            Type = ElementType.Unknown
        };

        // act
        var payload = SlackClient.SerializeObject(datePicker);

        // assert
        payload.Should().Contain("\"initial_date\":\"2019-11-01\"");
    }

    [Fact]
    public void ShouldSerializePlaceholder()
    {
        // arrange
        var placeholder = new TextObject
        {
            Type = TextObject.TextType.PlainText,
            Text = "Select a date"
        };
        var datePicker = new DatePicker
        {
            ActionId = "action_1",
            Placeholder = placeholder,
            Type = ElementType.Unknown
        };

        // act
        var placeholderPayload = SlackClient.SerializeObject(placeholder);
        var payload = SlackClient.SerializeObject(datePicker);

        // assert
        payload.Should().Contain($"\"placeholder\":{placeholderPayload}");
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
        var datePicker = new DatePicker
        {
            ActionId = "action_1",
            Confirm = confirm,
            Type = ElementType.Unknown
        };

        // act
        var confirmPayload = SlackClient.SerializeObject(confirm);
        var payload = SlackClient.SerializeObject(datePicker);

        // assert
        payload.Should().Contain($"\"confirm\":{confirmPayload}");
    }
}
