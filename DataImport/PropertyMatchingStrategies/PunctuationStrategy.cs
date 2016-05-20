using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies
{
    public class PunctuationStrategy : IPropertyMatcher
    {
        const string WhiteSpace = " ";

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty.Equals(null) || databaseProperty.Equals(null))
            {
                return false;
            }
            return IsMatch(agencyProperty.Name, databaseProperty.Name)
                && IsMatch(agencyProperty.Address, databaseProperty.Address);
        }

        private bool IsMatch(string agencyValue, string databaseValue)
        {
            if (string.IsNullOrWhiteSpace(agencyValue) || string.IsNullOrWhiteSpace(databaseValue))
            {
                return false;
            }
            // I've made an assumption here, that punctuations could be any character other than alphanumeric and space
            // This regex pattern could be replaced with a list of valid characters if my assumption is not true
            var pattern = @"([^a-zA-Z\d\s])";
            var regex = new Regex(pattern);
            var cleanAgencyValue = regex.Replace(agencyValue, WhiteSpace)
                                        .TrimAndRemoveDuplicateWhitespaces();
            var cleanDatabaseValue = regex.Replace(databaseValue, WhiteSpace)
                                        .TrimAndRemoveDuplicateWhitespaces();
            return cleanAgencyValue.IsNotEmptyAndEquals(cleanDatabaseValue);
        }
    }
}
