using jjm.one.Slack.Webhooks.Interfaces;

namespace jjm.one.Slack.Webhooks.Blocks;

/// <summary>
///     Displays message context, which can include both images and text.
/// </summary>
public class Context : Block
{
    /// <summary>
    ///     Create a new <see cref="Context" /> instance.
    /// </summary>
    public Context() : base(BlockType.Context)
    {
    }

    /// <summary>
    ///     An array of <see cref="Elements.Image" /> elements and <see cref="Elements.TextObject" />s. Maximum number of items
    ///     is 10.
    /// </summary>
    public List<IContextElement> Elements { get; set; }
}