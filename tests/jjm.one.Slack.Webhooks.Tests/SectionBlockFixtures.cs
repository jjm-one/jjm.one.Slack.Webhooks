using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class SectionBlockFixtures
{
    [Fact]
    public void ShouldSerializeText()
    {
        // arrange
        var textObject = new TextObject
        {
            Text = "This is text",
            Type = TextObject.TextType.PlainText
        };
        var section = new Section
        {
            BlockId = "section_block_1",
            Text = textObject
        };

        // act
        var textPayload = SlackClient.SerializeObject(textObject);
        var payload = SlackClient.SerializeObject(section);

        // assert
        payload.Should().Contain($"\"text\":{textPayload}");
    }

    [Fact]
    public void ShouldSerializeFields()
    {
        // arrange
        var fieldsList = new List<TextObject>
        {
            new() { Text = "Field 1", Type = TextObject.TextType.PlainText },
            new() { Text = "Field 2", Type = TextObject.TextType.PlainText }
        };
        var section = new Section
        {
            BlockId = "section_block_2",
            Text = new TextObject { Text = "Section Text", Type = TextObject.TextType.PlainText },
            Fields = fieldsList
        };

        // act
        var fieldsPayload = SlackClient.SerializeObject(fieldsList);
        var payload = SlackClient.SerializeObject(section);

        // assert
        payload.Should().Contain($"\"fields\":{fieldsPayload}");
    }

    [Fact]
    public void ShouldSerializeAccessory()
    {
        // arrange
        var button = new Button
        {
            ActionId = "button_1",
            Text = new TextObject
            {
                Text = "Click Me",
                Type = TextObject.TextType.PlainText
            },
            Type = ElementType.Unknown
        };
        var section = new Section
        {
            BlockId = "section_block_3",
            Text = new TextObject { Text = "Section Text", Type = TextObject.TextType.PlainText },
            Accessory = button
        };

        // act
        var accessoryPayload = SlackClient.SerializeObject(button);
        var payload = SlackClient.SerializeObject(section);

        // assert
        payload.Should().Contain($"\"accessory\":{accessoryPayload}");
    }

    [Fact]
    public void ShouldSerializeBlockId()
    {
        // arrange
        var section = new Section
        {
            BlockId = "section_block_4",
            Text = new TextObject { Text = "Section Text", Type = TextObject.TextType.PlainText }
        };

        // act
        var payload = SlackClient.SerializeObject(section);

        // assert
        payload.Should().Contain("\"block_id\":\"section_block_4\"");
    }
}
