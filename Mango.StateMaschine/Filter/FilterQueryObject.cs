using System.Collections.Generic;

namespace Mango.StateMaschine.Filter
{
    public class FilterQueryObject<TObject> where TObject: class
    {
        public TObject[] Object { get; set; }
        public List<FilterProperty> PropertieFilters { get; set; }
    }
}
