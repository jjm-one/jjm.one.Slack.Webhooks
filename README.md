# Slack.Webhooks

Even simpler integration with Slack's Incoming/Outgoing webhooks API for .NET.

## Forked Project

This is a fork of **Slack.Webhooks**, which can be found at [https://github.com/mrb0nj/Slack.Webhooks](https://github.com/mrb0nj/Slack.Webhooks).

## IMPORTANT

On Feb 19th, 2020, Slack ended support for TLS version 1.0 and 1.1. This means you may (depending on your .NET version) need to force the use of TLS1.2.

If you receive an error stating that "The underlying connection was closed," it's quite possibly a TLS issue. You can work around this by setting the default TLS version using the following:

```csharp
System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
```

## Requirements

1. You must first enable the Webhooks integration for your Slack account to get the Token. You can enable it here: [Slack Incoming Webhooks](https://slack.com/services/new/incoming-webhook).
2. `jjm.one.Slack.Webhooks` depends on `Newtonsoft.Json`.

## Installation

The package is hosted on [NuGet](https://www.nuget.org/packages/jjm.one.Slack.Webhooks) and can be installed from the package manager:

```cmd
PM> Install-Package jjm.one.Slack.Webhooks
```

For older .NET framework support:

```cmd
PM> Install-Package jjm.one.Slack.Webhooks -Version 1.0.0
```

## Usage

### Creating a Slack Client

Create a `SlackClient` with your Webhook URL:

```csharp
var slackClient = new SlackClient("[YOUR_WEBHOOK_URL]");
```

### Sending a Basic Message

Create a new `SlackMessage`:

```csharp
var slackMessage = new SlackMessage
{
    Channel = "#random",
    Text = "Your message",
    IconEmoji = Emoji.Ghost,
    Username = "nerdfury"
};

slackClient.Post(slackMessage);
```

### Using Blocks

You can provide a list of `Block` objects in `SlackMessage.Blocks` to create more interactive content.

#### Divider Block

```csharp
slackMessage.Blocks = new List<Block>
{
    new Blocks.Divider()
};
```

#### Section Block

```csharp
slackMessage.Blocks = new List<Block>
{
    new Blocks.Section
    {
        Text = new TextObject("_markdown_")
        {
            Type = TextObject.TextType.Markdown
        },
        Fields = new List<TextObject>
        {
            new TextObject { Text = "Field 1" },
            new TextObject { Text = "Field 2" },
            new TextObject { Text = "Field 3" }
        }
    }
};
```

#### Section Block with Accessory

```csharp
var confirmation = new Confirmation
{
    Confirm = new TextObject("This OK?"),
    Text = new TextObject("This is the Text"),
    Deny = new TextObject("This is the Deny Text"),
    Title = new TextObject("Title")
};

var options = new List<Option>
{
    new Option
    {
        Text = new TextObject("Option1"),
        Value = "option1"
    },
    new Option
    {
        Text = new TextObject("Option2"),
        Value = "option2"
    }
};

var element = new Button
{
    Text = new TextObject { Text = "Button Text" },
    ActionId = "Button1_Click"
};

slackMessage.Blocks = new List<Block>
{
    new Blocks.Section
    {
        Text = new TextObject("_markdown_")
        {
            Type = TextObject.TextType.Markdown
        },
        Accessory = element
    }
};
```

### Attachments

Attachments can be added to a message:

```csharp
var slackAttachment = new SlackAttachment
{
    Fallback = "New open task [Urgent]: <http://url_to_task|Test out Slack message attachments>",
    Text = "New open task *[Urgent]*: <http://url_to_task|Test out Slack message attachments>",
    Color = "#D00000",
    Fields = new List<SlackField>
    {
        new SlackField
        {
            Title = "Notes",
            Value = "This is much *easier* than I thought it would be."
        }
    }
};

slackMessage.Attachments = new List<SlackAttachment> { slackAttachment };
```

For more information, see the [Slack API Documentation](https://api.slack.com/docs/attachments).

### Emoji

The `Emoji` class provides a comprehensive list of Slack emojis. For example:

```csharp
slackMessage.IconEmoji = Emoji.Smile;
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
