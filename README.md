# Nzr.ToolBox

![NuGet Version](https://img.shields.io/nuget/v/Nzr.Toolbox.Core.Single?link=https%3A%2F%2Fwww.nuget.org%2Fpackages%2FNzr.ToolBox.Core.Single)
![NuGet Downloads](https://img.shields.io/nuget/dt/Nzr.Toolbox.Core?logoColor=red&label=downloads%20(Core))
![NuGet Downloads](https://img.shields.io/nuget/dt/Nzr.Toolbox.Core.Single?logoColor=red&label=downloads%20(Single))
![GitHub last commit](https://img.shields.io/github/last-commit/marionzr/nzr.toolbox)
![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/marionzr/nzr.toolbox/ci.yaml)
![GitHub License](https://img.shields.io/github/license/marionzr/nzr.toolbox)

A collection of utility classes and extension methods that allow developers to have a social life.

# How to use

More examples about how to use it can be found at [Test Project](https://raw.githubusercontent.com/marionzr/Nzr.ToolBox/master/dotnet/Nzr.ToolBox.Core.Tests)

## Usings

Nzr.ToolBox is shipped in two compiled versions:

### Individual classes and extensions
https://www.nuget.org/packages/Nzr.ToolBox.Core/

Each utility class and the extensions methods were compiled in individual classes and
you need to import them individually, based on your needs.

```
using static Nzr.ToolBox.Core.BooleanUtils;
using static Nzr.ToolBox.Core.CollectionUtils;
using static Nzr.ToolBox.Core.DateTimeUtils;
using static Nzr.ToolBox.Core.EnumUtils;
using static Nzr.ToolBox.Core.NumberUtils;
using static Nzr.ToolBox.Core.ObjectUtils;
using static Nzr.ToolBox.Core.RandomUtils;
using static Nzr.ToolBox.Core.ReflectionUtils;
using static Nzr.ToolBox.Core.StringUtils;
```

### Combined all in one

https://www.nuget.org/packages/Nzr.ToolBox.Core.Single/

All the classes were compiled as partial classes named ToolBox and you just need one import to get
all extensions and utility classes.

```
using static Nzr.ToolBox.Core.ToolBox
```

## Change set

All notable changes to this project will be documented in this file.

### v1.0.0
Added the following group of utilities and extension methods:
* BooleanUtils
* CollectionUtils
* DateTimeUtils
* EnumUtils
* NumberUtils
* ObjectUtils
* RandomUtils
* ReflectionUtils
* StringUtils

### v1.1.0
Added null check for some extension methods.

### v1.2.0
Added new extensions:
* NumberUtils: PadLeft extension for numeric values.
* CollectionUtils: Contains extension for Arrays

### v1.3.0
Added new extensions:
* Equals: Compare string ignoring diacritics

### v1.4.0

Upgraded the projects to target net8.0
Upgraded all libraries to the latest version (27.07.2024)

### v1.4.1

Added new extensions to ObjectUtils:
* StringifyBuilder is a extension to build a better string representation of a object.

Upgraded all libraries to the latest version (14.09.2024)

### v1.6.1

Upgraded all libraries to the latest version (23.01.2025)

## License

Nzr.Nano is licensed under the Apache License, Version 2.0, January 2004. You may obtain a copy of the License at:

```
http://www.apache.org/licenses/LICENSE-2.0
```

# Disclaimer

This project is provided "as-is" without any warranty or guarantee of its functionality. The author assumes no responsibility or liability for any issues, damages, or consequences arising from the use of this code, whether direct or indirect. By using this project, you agree that you are solely responsible for any risks associated with its use, and you will not hold the author accountable for any loss, injury, or legal ramifications that may occur.

Please ensure that you understand the code and test it thoroughly before using it in any production environment.
