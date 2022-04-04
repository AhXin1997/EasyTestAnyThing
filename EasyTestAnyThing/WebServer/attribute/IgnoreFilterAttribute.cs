using System;

namespace EasyTestAnyThing.WebServer.attribute
{
    public class IgnoreFilterAttribute : Attribute
    {
        public Type FilterType { get; }

        public IgnoreFilterAttribute(Type filterType)
        {
            FilterType = filterType;
        }
    }
}