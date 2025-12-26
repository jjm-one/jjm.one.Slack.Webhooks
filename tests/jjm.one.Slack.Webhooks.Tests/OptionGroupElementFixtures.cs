using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class OptionGroupElementFixtures
{
    [Fact]
    public void ShouldSerializeLabel()
    {
        // arrange
        var text = new TextObject
        {
            Text = "Group Label",
            Type = TextObject.TextType.PlainText
        };
        var group = new OptionGroup
        {
            Label = text,
            Options = new List<Option>
            {
                new() { Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText }, Value = "value_1" }
            }
        };

        // act
        var textPayload = SlackClient.SerializeObject(text);
        var payload = SlackClient.SerializeObject(group);

        // assert
        payload.Should().Contain($"\"label\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeOptions()
    {
        // arrange
        var options = new List<Option>
        {
            new() { Text = new TextObject { Text = "Option 1", Type = TextObject.TextType.PlainText }, Value = "value_1" },
            new() { Text = new TextObject { Text = "Option 2", Type = TextObject.TextType.PlainText }, Value = "value_2" }
        };
        var group = new OptionGroup
        {
            Label = new TextObject { Text = "Group Label", Type = TextObject.TextType.PlainText },
            Options = options
        };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(group);

        // assert
        payload.Should().Contain($"\"options\":{optionsPayload}");
    }
}
