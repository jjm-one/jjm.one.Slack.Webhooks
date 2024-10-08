using jjm.one.Slack.Webhooks.Elements;

namespace jjm.one.Slack.Webhooks.Blocks;

/// <summary>
///     A <see cref="Header" /> is a plain-text block that displays in a larger, bold font.
///     Use it to delineate between different groups of content in your app's surfaces.
/// </summary>
public class Header : Block
{
    /// <summary>
    ///     Create a new <see cref="Header" /> instance.
    /// </summary>
    public Header() : base(BlockType.Header)
    {
    }

    /// <summary>
    ///     The <see cref="Text" /> for the block, in the form of a <see cref="TextObject" />.
    ///     Maximum length for the <c>text</c> in this field is 150 characters.
    /// </summary>
    public TextObject Text { get; set; }
}