using Domain.CodeChallenge.DataImport.PropertyMatchingStrategies;

namespace Domain.CodeChallenge.DataImport
{
    /// <summary>
    /// Handles matchings for all types of properties (All Agencies)
    /// </summary>
    public class PropertyMatchContext : IPropertyMatcher
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            var strategy = PropertyMatchingStrategyFactory.Create(agencyProperty.AgencyCode);
            return strategy.IsMatch(agencyProperty, databaseProperty);
        }
    }
}
