using System;

namespace Mango.StateMaschine.Models
{
    public class ObjectToFilter
    {
        public int Id { get; set; }
        public string MyString { get; set; }
        public DateTime MxDateTime { get; set; }
        public ObjectToFilter[] MyObjects { get; set; }
    }
}
