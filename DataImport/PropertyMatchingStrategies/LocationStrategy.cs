using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies
{
    public class LocationStrategy : IPropertyMatcher
    {
        const double DistanceTolerance = 200; // meters (Assumption in the specs)

        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            // this has been added according to the specs
            if (agencyProperty.AgencyCode != databaseProperty.AgencyCode)
            {
                return false;
            }
            // I could have calculated Great Circle distance which is more accurate
            // but as we just need to check small distances (around 200m) we can use flat distance
            // which needs less calculations and is faster
            var distance = GeoLocationHelper.CalculateFlatDistance(agencyProperty.Latitude, agencyProperty.Longitude,
                                                                    databaseProperty.Latitude, databaseProperty.Longitude);
            return distance <= DistanceTolerance;
        }


    }
}
