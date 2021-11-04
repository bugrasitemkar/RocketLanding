using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

/// GetDisplayName method code is copied from the following address:
/// https://benjaminray.com/codebase/c-enum-display-names-with-spaces-and-special-characters/
/// 2021-11-04

namespace RocketLanding.Extensions
{
    /// <summary>
    ///     Extensions for Enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Returns Display name annotation for enum members
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}
