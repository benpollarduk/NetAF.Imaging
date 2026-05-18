# NetAF.Imaging
Extension to add simple imaging capabilities to NetAF.

## Overview
NetAF.Imaging provides extensions to [NetAF](https://github.com/benpollarduk/NetAF) to add simple functions to convert images to visuals.

## Getting Started

### Clone the repo/pull NuGet
Clone the repo:
```bash
git clone https://github.com/benpollarduk/netaf.imaging.git
```
Or add the NuGet package:
```bash
dotnet add package NetAF.Imaging
```

### Hello World
Generating visuals is made easy with the *VisualHelper* class. The following example generates a visual on the console:

```csharp
var displaySize = new Size(80, 50);
var adapter = new ConsoleAdapter();

var frame = VisualHelper.CreateFrame(@"C:\TestImage.jpg", displaySize, CellAspectRatio.Console);
adapter.RenderFrame(frame);
```

This can be used in a game:

```csharp
var visualBuilder = VisualHelper.FromImage(@"C:\TestImage.jpg", displaySize, CellAspectRatio.Console);
var visual = new Visual("Test image", "A test image", visualBuilder);
game.ChangeMode(new VisualMode(visual));
```

Here is a simple room that contains a command to look at the view.

```csharp
return new Room("Hillside", "A wild hillside with a lone tree", commands:
[
    new CustomCommand(new CommandHelp("Look at view", "Look at the current view."), true, true, (game, args) =>
    {
        var visualBuilder = VisualHelper.FromImage(@"C:\TestImage.jpg", displaySize, CellAspectRatio.Console);
        var visual = new Visual("Test image", "A test image", visualBuilder);
        game.ChangeMode(new VisualMode(visual));
        return new(ReactionResult.GameModeChanged, string.Empty);
    })
 ]);
```

### Applying Textures
A texturizer can be applied to add extra depth to the image:

```csharp
var frame = VisualHelper.CreateFrame(@"C:\TestImage.jpg", displaySize, CellAspectRatio.Console, new BrightnessTexturizer());
```

## Documentation
Please visit [https://benpollarduk.github.io/NetAF-docs/docs/visuals.html](https://benpollarduk.github.io/NetAF-docs/docs/visuals.html) to view the NetAF.Imaging documentation.

## For Open Questions
Visit https://github.com/benpollarduk/NetAF.Imaging/issues

