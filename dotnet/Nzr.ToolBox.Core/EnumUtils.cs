using System;
using System.Collections.Generic;
using System.Linq;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Enum types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class EnumUtils
#endif
    {
        /// <summary>
        /// Return a List of
        /// </summary>
        /// <typeparam name="E">Type of the enum.</typeparam>
        /// <returns></returns>
        public static IList<string> GetEnumNames<E>() where E : Enum =>
            Enum.GetValues(typeof(E))
            .Cast<E>()
            .Select(e => e.ToString())
            .ToList();
    }
}
