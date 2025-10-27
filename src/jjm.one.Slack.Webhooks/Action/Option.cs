namespace jjm.one.Slack.Webhooks.Action;

/// <summary>
///     Represents a selectable option in a menu or other interactive element.
/// </summary>
public class Option
{
    /// <summary>
    ///     The text displayed for the option. Maximum length is 75 characters.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    ///     The value sent to your app when this option is selected. Maximum length is 75 characters.
    /// </summary>
    public required string Value { get; set; }
}
