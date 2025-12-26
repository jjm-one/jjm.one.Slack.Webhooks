using File = jjm.one.Slack.Webhooks.Blocks.File;

namespace jjm.one.Slack.Webhooks.Tests;

public class FileBlockFixtures
{
    [Fact]
    public void ShouldHaveExternalId()
    {
        // arrange
        var file = new File
        {
            BlockId = "file_block_1",
            ExternalId = "AB_1234"
        };

        // act
        var payload = SlackClient.SerializeObject(file);

        // assert
        payload.Should().Contain("\"external_id\":\"AB_1234\"");
    }

    [Fact]
    public void ShouldHaveRemoteSourceByDefault()
    {
        // arrange
        var file = new File
        {
            BlockId = "file_block_2",
            ExternalId = "CD_5678"
        };

        // act
        var payload = SlackClient.SerializeObject(file);

        // assert
        file.Source.Should().Be("remote");
        payload.Should().Contain("\"source\":\"remote\"");
    }

    [Fact]
    public void ShouldSerializeBlockId()
    {
        // arrange
        var file = new File
        {
            BlockId = "file_block_3",
            ExternalId = "EF_91011"
        };

        // act
        var payload = SlackClient.SerializeObject(file);

        // assert
        payload.Should().Contain("\"block_id\":\"file_block_3\"");
    }
}
