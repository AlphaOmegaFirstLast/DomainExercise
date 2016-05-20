using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies
{
    public class BackwardNameStrategy : IPropertyMatcher
    {
        const char WhiteSpace = ' ';

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (string.IsNullOrWhiteSpace(agencyProperty.Name) || string.IsNullOrWhiteSpace(databaseProperty.Name))
            {
                return false;
            }
            var agencyPropertyName = agencyProperty.Name.TrimAndRemoveDuplicateWhitespaces();
            var databasePropertyName = databaseProperty.Name.TrimAndRemoveDuplicateWhitespaces();
            var agencyArr = agencyPropertyName.Split(WhiteSpace).Reverse();
            var reversedAgencyName = string.Join(WhiteSpace.ToString(), agencyArr);
            return reversedAgencyName.IsNotEmptyAndEquals(databasePropertyName);
        }
    }
}
