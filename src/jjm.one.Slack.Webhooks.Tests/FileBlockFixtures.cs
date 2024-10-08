using File = jjm.one.Slack.Webhooks.Blocks.File;

namespace jjm.one.Slack.Webhooks.Tests;

using File = File;

public class FileBlockFixtures
{
    [Fact]
    public void ShouldHaveExternalId()
    {
        // arrange
        var file = new File { ExternalId = "AB_1234" };

        // act
        var payload = SlackClient.SerializeObject(file);

        // assert
        payload.Should().Contain("\"external_id\":\"AB_1234\"");
    }

    [Fact]
    public void ShouldHaveRemoteSourceByDefault()
    {
        // arrange
        var file = new File();

        // act
        var payload = SlackClient.SerializeObject(file);

        // assert
        file.Source.Should().Be("remote");
        payload.Should().Contain("\"source\":\"remote\"");
    }
}