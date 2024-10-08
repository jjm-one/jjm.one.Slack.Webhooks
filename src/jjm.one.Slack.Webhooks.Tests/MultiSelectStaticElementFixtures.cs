using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Tests;

public class MultiSelectStaticElementFixtures
{
    [Fact]
    public void ShouldSerializeOptions()
    {
        // arrange
        var options = new List<Option> { new() { Value = "Value123" } };
        var select = new MultiSelectStatic { Options = options };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"options\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeInitialOptions()
    {
        // arrange
        var options = new List<Option> { new() { Value = "Value123" } };
        var select = new MultiSelectStatic { InitialOptions = options };

        // act
        var optionsPayload = SlackClient.SerializeObject(options);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"initial_options\":{optionsPayload}");
    }

    [Fact]
    public void ShouldSerializeInitialOptionGroup()
    {
        // arrange
        var options = new List<Option> { new() { Value = "Value123" } };
        var groups = new List<OptionGroup> { new() { Options = options } };
        var select = new MultiSelectStatic { OptionGroups = groups };

        // act
        var groupsPayload = SlackClient.SerializeObject(groups);
        var payload = SlackClient.SerializeObject(select);

        // assert
        payload.Should().Contain($"\"option_groups\":{groupsPayload}");
    }
}