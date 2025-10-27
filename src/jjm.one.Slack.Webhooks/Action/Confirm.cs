namespace jjm.one.Slack.Webhooks.Action;

/// <summary>
///     Represents a confirmation dialog that provides a way to confirm or cancel an action.
/// </summary>
public class Confirm
{
    /// <summary>
    ///     A plain-text title for the confirmation dialog. Maximum length is 100 characters.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     A plain-text or markdown text that explains the confirmation dialog. Maximum length is 300 characters.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    ///     The text for the button that confirms the action. Maximum length is 30 characters.
    /// </summary>
    public required string OkText { get; set; }

    /// <summary>
    ///     The text for the button that cancels the action. Maximum length is 30 characters.
    /// </summary>
    public required string DismissText { get; set; }
}
