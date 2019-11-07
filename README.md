# Nzr.ToolBox   
A collection of utility classes and extension methods that allow developers to have a social life.

# How to use

More examples about how to use it can be found at [Test Project](https://raw.githubusercontent.com/marionzr/Nzr.ToolBox/master/dotnet/Nzr.ToolBox.Core.Tests)


## Usings

Nzr.ToolBox is shipped in two compiled versions:
1. Individual classes and extensions: Each utility class and the extensions methods were compiled in individual classes and
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

2. Combined all in one: All the classes were compiled as partial classes named ToolBox and you just need one import to get
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

## Know Issues

There are no known issues so far. The tests were written as a how-to guide but also to cover almost 100% of the code (currently 99.5% (680 of 683) line covered and 99.3% (290 of 292) branch covered).

