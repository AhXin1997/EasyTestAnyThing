using EasyTestAnyThing.CSharpReflection.FakeDb;
using System;
using System.Linq;

namespace EasyTestAnyThing.CSharpReflection.Factory
{
    public static class GetApiParameterFactory
    {
        public static string GetParameter(string key)
        {
            var fakeDb = new ConnFakeDb();
            var value = fakeDb.DbTable.Datas.Where(w => w.Key == key).Select(s => s.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException($"Can't_Find_{key}_Value");
            }

            return value;
        }
    }
}