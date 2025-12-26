using jjm.one.Slack.Webhooks.Blocks;
using jjm.one.Slack.Webhooks.Elements;
using jjm.one.Slack.Webhooks.Interfaces;
using File = jjm.one.Slack.Webhooks.Blocks.File;

namespace jjm.one.Slack.Webhooks.Tests;

public class BlockFixtures
{
    [Theory]
    [MemberData(nameof(GetData))]
    public void ShouldHaveBlockTypeAndBlockId(Block block, string expectedType, string expectedBlockId)
    {
        // arrange/act
        var payload = SlackClient.SerializeObject(block);

        // assert
        payload.Should().Contain($"\"type\":\"{expectedType}\"");
        payload.Should().Contain($"\"block_id\":\"{expectedBlockId}\"");
    }

    public static IEnumerable<object[]> GetData()
    {
        return new List<object[]>
        {
            new object[] { new Divider { BlockId = "0001" }, "divider", "0001" },
            new object[]
            {
                new Blocks.Image
                {
                    BlockId = "0002",
                    ImageUrl = "https://example.com/image.png",
                    AltText = "Example Image"
                },
                "image",
                "0002"
            },
            new object[]
            {
                new Section
                {
                    BlockId = "0003",
                    Text = new TextObject
                    {
                        Type = TextObject.TextType.PlainText,
                        Text = "Section Text"
                    }
                },
                "section",
                "0003"
            },
            new object[]
            {
                new Context
                {
                    BlockId = "0004",
                    Elements = new List<IContextElement>
                    {
                        new TextObject
                        {
                            Type = TextObject.TextType.PlainText,
                            Text = "Context Text"
                        }
                    }
                },
                "context",
                "0004"
            },
            new object[]
            {
                new File
                {
                    BlockId = "0005",
                    ExternalId = "file_123",
                    Source = "remote"
                },
                "file",
                "0005"
            },
            new object[]
            {
                new Actions
                {
                    BlockId = "0006",
                    Elements = new List<IActionElement>
                    {
                        new Button
                        {
                            ActionId = "button_1",
                            Text = new TextObject
                            {
                                Type = TextObject.TextType.PlainText,
                                Text = "Click Me"
                            },
                            Type = ElementType.Unknown
                        }
                    }
                },
                "actions",
                "0006"
            },
            new object[]
            {
                new Input
                {
                    BlockId = "0007",
                    Label = new TextObject
                    {
                        Type = TextObject.TextType.PlainText,
                        Text = "Input Label"
                    },
                    Element = new PlainTextInput
                    {
                        ActionId = "input_1",
                        Type = ElementType.Unknown
                    }
                },
                "input",
                "0007"
            },
            new object[]
            {
                new Header
                {
                    BlockId = "0008",
                    Text = new TextObject
                    {
                        Type = TextObject.TextType.PlainText,
                        Text = "Header Text"
                    }
                },
                "header",
                "0008"
            }
        };
    }
}
