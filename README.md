# Nzr.ToolBox   
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

#### v1.0.0
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

#### v1.1.0
Added null check for some extension methods.

#### v1.2.0
Added new extensions:
* NumberUtils: PadLeft extension for numeric values.
* CollectionUtils: Contains extension for Arrays

#### v1.3.0
Added new extensions:
* Equals: Compare string ignoring diacritics

Fixed bugs:
https://github.com/marionzr/Nzr.ToolBox/issues/1
https://github.com/marionzr/Nzr.ToolBox/issues/2

## Know Issues

There are no known issues so far. The tests were written as a how-to guide but also to cover almost 100% of the code (currently 99.5% (718 of 721) line covered and 99.6% (305 of 306) branch covered).

