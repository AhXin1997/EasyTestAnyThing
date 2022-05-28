using System;

namespace EasyTestAnyThing.WebServer.Attribute
{
    public class IgnoreFilterAttribute : System.Attribute
    {
        public Type FilterType { get; }

        public IgnoreFilterAttribute(Type filterType)
        {
            FilterType = filterType;
        }
    }
}