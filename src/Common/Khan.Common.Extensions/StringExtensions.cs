using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Khan.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert word's accentuation from normal word.
        /// </summary>
        public static string ClearAccent(this string value)
        {
            var normalizedString = value.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        /// <summary>
        /// Verify if this phrase contains a word like param
        /// </summary>
        public static bool PhaseLike(this string value, string compare)
        {
            bool howToReturn = false;

            howToReturn = value.StartsWith(compare);
            howToReturn = value.EndsWith(compare);
            howToReturn = value.Contains(compare, StringComparison.InvariantCulture);
            howToReturn = value.Equals(compare);

            return howToReturn;
        }
    }
}
