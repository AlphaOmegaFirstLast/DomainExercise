using System.Collections.Generic;
using Domain.CodeChallenge.DataImport.PropertyMatchingStrategies;

namespace Domain.CodeChallenge.DataImport
{
    /// <summary>
    /// This class is responsible to create proper strategy according to the agency
    /// </summary>
    public class PropertyMatchingStrategyFactory
    {
        private static Dictionary<string, IPropertyMatcher> _strategyCache = new Dictionary<string, IPropertyMatcher>();

        public static IPropertyMatcher Create(string agentCode)
        {
            switch (agentCode)
            {
                case "OTBRE":
                    return GetOrAdd<PunctuationStrategy>(agentCode);
                case "LRE":
                    return GetOrAdd<LocationStrategy>(agentCode);
                case "CRE":
                    return GetOrAdd<BackwardNameStrategy>(agentCode);
                default:
                    return GetOrAdd<GenericStrategy>(agentCode);
            }
        }

        private static T GetOrAdd<T>(string key)
            where T : IPropertyMatcher, new()
        {
            T result;
            if (_strategyCache.ContainsKey(key))
            {
                result = (T)_strategyCache[key];
            }
            else
            {
                result = new T();
                _strategyCache[key] = result;
            }
            return result;
        }
    }
}
