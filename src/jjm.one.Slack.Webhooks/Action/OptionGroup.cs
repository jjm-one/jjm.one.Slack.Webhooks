namespace jjm.one.Slack.Webhooks.Action;

/// <summary>
///     Represents a group of selectable options in a menu or other interactive element.
/// </summary>
public class OptionGroup
{
    /// <summary>
    ///     The label for the option group. Maximum length is 75 characters.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    ///     A list of <see cref="Option" /> objects that belong to this group. Maximum of 100 items.
    /// </summary>
    public required List<Option> Options { get; set; }
}
