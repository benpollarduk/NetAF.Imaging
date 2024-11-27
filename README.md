<div align="center">

# NetAF.Imaging
NetAF.Imaging extension to add simple imaging capabilities to NetAF.

![icon](.nuget/Icon.bmp)

[![main-ci](https://github.com/benpollarduk/NetAF.Imaging/actions/workflows/main-ci.yml/badge.svg)](https://github.com/benpollarduk/NetAF.Imaging/actions/workflows/main-ci.yml)
[![GitHub release](https://img.shields.io/github/release/benpollarduk/NetAF.Imaging.svg)](https://github.com/benpollarduk/NetAF.Imaging/releases)
[![NuGet](https://img.shields.io/nuget/v/netaf.imaging.svg)](https://www.nuget.org/packages/netaf.imaging/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/netaf.imaging)](https://www.nuget.org/packages/netaf.imaging/)
[![codecov](https://codecov.io/gh/benpollarduk/NetAF.Imaging/graph/badge.svg?token=CFqSF657Oc)](https://codecov.io/gh/benpollarduk/NetAF.Imaging)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_NetAF.Imaging&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=benpollarduk_NetAF.Imaging)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_NetAF.Imaging&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=benpollarduk_NetAF.Imaging)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_NetAF.Imaging&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=benpollarduk_NetAF.Imaging)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_NetAF.Imaging&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=benpollarduk_NetAF.Imaging)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_NetAF.Imaging&metric=bugs)](https://sonarcloud.io/summary/new_code?id=benpollarduk_NetAF.Imaging)
[![License](https://img.shields.io/github/license/benpollarduk/NetAF.Imaging.svg)](https://opensource.org/licenses/MIT)

</div>

## Overview
NetAF.Imaging extension to add simple imaging capabilities to [NetAF](https://github.com/benpollarduk/NetAF).

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

### Example
Generating visuals is made easy with the *VisualHelper* class. The following example generates a visual on the console:
```csharp
var displaySize = new Size(80, 50);
var fontSize = new CellSize(8, 12);
var adapter = new SystemConsoleAdapter();

var frame = new GridVisualFrame(VisualHelper.FromImage(@"C:\TestImage.jpg", displaySize, fontSize));
adapter.RenderFrame(frame);
```

The rendered visual:

![image](https://github.com/user-attachments/assets/92575c55-ffd4-4802-81af-b68c206b4e10)

This can be used in a game:

```csharp
var frame = new GridVisualFrame(VisualHelper.FromImage(@"C:\TestImage.jpg", displaySize, fontSize));
game.ChangeMode(new VisualMode(frame));
```

Here is a simple room that contains a command to look at the view.
```csharp
return new Room("Hillside", "A wild hillside with a lone tree", commands:
[
    new CustomCommand(new CommandHelp("Look at view", "Look at the current view."), true, true, (game, args) =>
    {
        var frame = new GridVisualFrame(VisualHelper.FromImage(imagePath, game.Configuration.DisplaySize, new CellSize(8, 12)));
        game.ChangeMode(new VisualMode(frame));
        return new(ReactionResult.GameModeChanged, string.Empty);
    })
 ]);
```

## Documentation
Please visit [https://benpollarduk.github.io/NetAF-docs/](https://benpollarduk.github.io/NetAF-docs/) to view the NetAF documentation.

## For Open Questions
Visit https://github.com/benpollarduk/NetAF.Imaging/issues
