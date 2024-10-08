using Newtonsoft.Json;

namespace jjm.one.Slack.Webhooks.Tests;

public class EmojiShould
{
    [Fact]
    public void SerializeToString()
    {
        //arrange
        var emoji = Emoji.Ghost;

        //act
        var serialized = JsonConvert.SerializeObject(emoji);

        //assert
        Assert.Equal("\":ghost:\"", serialized);
    }

    [Fact]
    public void DeserializeToObject()
    {
        //arrange and act
        var deserialized = JsonConvert.DeserializeObject<string>("\":ghost:\"");

        //assert
        Assert.Equal(Emoji.Ghost, deserialized);
    }

    [Fact]
    public void BeComparable()
    {
        var ghost1 = Emoji.Ghost;
        var ghost2 = JsonConvert.DeserializeObject<string>("\":ghost:\"");
        Assert.Equal(ghost1, ghost2);
    }
}