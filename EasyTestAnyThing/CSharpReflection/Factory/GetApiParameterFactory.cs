using EasyTestAnyThing.CSharpReflection.FakeDb;
using System;

namespace EasyTestAnyThing.CSharpReflection.Factory
{
    public static class GetApiParameterFactory
    {
        public static string GetParameter(string key)
        {
            var fakeDb = new ConnFakeDb();
            fakeDb.DbTable.Item.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException(string.Format("Can't_Find_{0}_Value",key));
            }

            return value;
        }
    }
}