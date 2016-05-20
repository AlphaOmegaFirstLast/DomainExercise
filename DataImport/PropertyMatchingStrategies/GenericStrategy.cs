using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies
{
    // This strategy was not in the test specs but I have added it as a fallback strategy
    // in case of other agencies
    public class GenericStrategy : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty == null || databaseProperty == null)
            {
                return false;
            }
            return agencyProperty.Address.IsNotEmptyAndEquals(databaseProperty.Address);
        }
    }
}
