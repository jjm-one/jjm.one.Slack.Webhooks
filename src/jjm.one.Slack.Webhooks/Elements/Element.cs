namespace jjm.one.Slack.Webhooks.Elements;

public class Element
{
    /// <summary>
    ///     Create a new <see cref="Element" /> instance with the specified <see cref="ElementType" />.
    /// </summary>
    /// <param name="elementType">The type of the element.</param>
    protected Element(ElementType elementType) => Type = elementType;

    /// <summary>
    ///     The type of element represented by <see cref="ElementType" />.
    /// </summary>
    public required ElementType Type { get; set; }

    /// <summary>
    ///     Determines whether the <see cref="Type" /> property should be serialized.
    /// </summary>
    /// <returns>True if the type is not <see cref="ElementType.Unknown" />, otherwise false.</returns>
    public bool ShouldSerializeType() => Type != ElementType.Unknown;
}
