using jjm.one.Slack.Webhooks.Blocks;

namespace jjm.one.Slack.Webhooks.Tests;

public class SlackMessageFixtures
{
    [Fact]
    public void ShouldCloneAllProperties()
    {
        // arrange
        SlackMessage message = GetSlackMessage();

        // act
        SlackMessage clonedMessage = message.Clone();

        // assert
        Assert.Equal(message.Text, clonedMessage.Text);
        Assert.Equal(message.ResponseType, clonedMessage.ResponseType);
        Assert.Equal(message.ReplaceOriginal, clonedMessage.ReplaceOriginal);
        Assert.Equal(message.DeleteOriginal, clonedMessage.DeleteOriginal);
        Assert.Equal(message.Channel, clonedMessage.Channel);
        Assert.Equal(message.Username, clonedMessage.Username);
        Assert.Equal(message.IconEmoji, clonedMessage.IconEmoji);
        Assert.Equal(message.IconUrl, clonedMessage.IconUrl);
        Assert.Equal(message.Markdown, clonedMessage.Markdown);
        Assert.Equal(message.LinkNames, clonedMessage.LinkNames);
        Assert.Equal(message.Parse, clonedMessage.Parse);
        Assert.Equal(message.ThreadId, clonedMessage.ThreadId);
        Assert.Equal(message.Attachments, clonedMessage.Attachments);
        Assert.Equal(message.Blocks, clonedMessage.Blocks);
    }

    [Fact]
    public void ShouldSerializeAllProperties()
    {
        // arrange
        SlackMessage message = GetSlackMessage();

        // act
        var payload = SlackClient.SerializeObject(message);

        // assert
        Assert.Contains($"\"text\":\"{message.Text}\"", payload);
        Assert.Contains($"\"response_type\":\"{message.ResponseType}\"", payload);
        Assert.Contains($"\"replace_original\":{message.ReplaceOriginal.ToString().ToLower()}", payload);
        Assert.Contains($"\"delete_original\":{message.DeleteOriginal.ToString().ToLower()}", payload);
        Assert.Contains($"\"channel\":\"{message.Channel}\"", payload);
        Assert.Contains($"\"username\":\"{message.Username}\"", payload);
        Assert.Contains($"\"icon_emoji\":\"{message.IconEmoji}\"", payload);
        Assert.Contains($"\"icon_url\":\"{message.IconUrl}\"", payload);
        Assert.Contains($"\"mrkdwn\":{message.Markdown.ToString().ToLower()}", payload);
        Assert.Contains($"\"link_names\":{message.LinkNames.ToString().ToLower()}", payload);
        Assert.Contains($"\"parse\":\"{message.Parse}\"", payload);
        Assert.Contains($"\"thread_ts\":\"{message.ThreadId}\"", payload);
        Assert.Contains("\"attachments\":", payload);
        Assert.Contains("\"blocks\":", payload);
    }

    private static SlackMessage GetSlackMessage()
    {
        return new SlackMessage
        {
            Text = $"Test {nameof(SlackMessage.Text)}",
            ResponseType = $"Test {nameof(SlackMessage.ResponseType)}",
            ReplaceOriginal = true,
            DeleteOriginal = true,
            Channel = $"Test {nameof(SlackMessage.Channel)}",
            Username = $"Test {nameof(SlackMessage.Username)}",
            IconEmoji = Emoji.Cactus,
            IconUrl = new Uri("http://test.com/icon.jpg"),
            Markdown = true,
            LinkNames = true,
            Parse = ParseMode.Full,
            ThreadId = $"Test {nameof(SlackMessage.ThreadId)}",
            Attachments = new List<SlackAttachment> { new()
                {
                    Fallback = null
                }
            },
            Blocks = new List<Block> { new Context
                {
                    Elements = null,
                    BlockId = null
                }
            }
        };
    }
}
