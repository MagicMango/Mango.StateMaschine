using Mango.StateMaschine.Filter;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Mango.StateMaschine.Extensions
{
    public static class FilterQueryObjectExtension
    {
        public static (string where, object[] parameters) ToDynamicFilter<TObject>(this FilterQueryObject<TObject> filterQueryObject)
            where TObject : class
        {
            string where = null;
            var props = typeof(TObject).GetProperties();
            int i = 0;
            foreach (var filter in filterQueryObject.PropertieFilters)
            {
                //if (!props.Any(x => x.Name == filter.Property))
                //    return

                where += filter.Method switch
                {
                    "Equals" => filter.Property + string.Format("==@{0} &&", i),
                    "Contains" => filter.Property + string.Format(".Contains(@{0}) &&", i),
                    "StartsWith" => filter.Property + string.Format(".StartsWith(@{0}) &&", i),
                    "EndsWith" => filter.Property + string.Format(".EndsWith(@{0}) &&", i),
                    _ => string.Empty
                };
                i++;
            }
            return  (where?.Substring(0, where.Length - 2) ?? "", filterQueryObject.PropertieFilters.Select(x => x.Value).ToArray());
        }
    }
}
