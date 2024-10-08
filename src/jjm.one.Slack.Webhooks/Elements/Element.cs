namespace jjm.one.Slack.Webhooks.Elements;

public class Element
{
    protected Element(ElementType elementType)
    {
        Type = elementType;
    }

    /// <summary>
    ///     The type of element represented by <see cref="ElementType" />.
    /// </summary>
    public ElementType Type { get; set; }

    public bool ShouldSerializeType()
    {
        return Type != ElementType.Unknown;
    }
}