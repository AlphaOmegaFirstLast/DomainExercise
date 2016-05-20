using System;
using System.Text.RegularExpressions;

namespace Domain.CodeChallenge.DataImport
{
    public static class StringExtensionMethods
    {
        public static bool IsNotEmptyAndEquals(this string value1, string value2)
        {
            return !(string.IsNullOrWhiteSpace(value1) || string.IsNullOrWhiteSpace(value1))
                   && value1.Equals(value2, StringComparison.OrdinalIgnoreCase);
        }

        public static string TrimAndRemoveDuplicateWhitespaces(this string input)
        {
            return Regex.Replace(input.Trim(), @"\s+", " ");
        }
    }
}