using System;
using System.Collections.Generic;

namespace EasyTestAnyThing.Tool
{
    public class EasyOutputMessage
    {
        private class Item
        {
            //需轉換的Properties
        }

        public void EasyOutputMessageMethod()
        {
            var list = new List<string>();

            //ToAccessors(list);
            //ToSql(list);

            list.ForEach(f => Console.WriteLine(f));
            Console.ReadKey();
        }

        private const string Accessors = "{get; set;}";
        private void ToAccessors(List<string> list)
        {
            foreach (var index in typeof(Item).GetProperties())
            {
                list.Add($"public {PropertyTypeExtensionToAccessors(index.PropertyType)} {index.Name} " + Accessors);
            }
        }

        private void ToSql(List<string> list)
        {
            list.Add("Name\tType\tAllow Null");
            foreach (var index in typeof(Item).GetProperties())
            {
                list.Add($"{index.Name}\t{PropertyTypeExtensionToSqlType(index.PropertyType)}\t" + ",");
            }
        }

        private string PropertyTypeExtensionToAccessors(Type propertyType)
        {
            switch (propertyType.ToString().Replace("System.", "").ToLower())
            {
                case "string":
                    return "string";

                case "datetime":
                    return "DateTime";

                case "int32":
                    return "int";

                case "int64":
                    return "long";

                case "decimal":
                    return "decimal";

                case "boolean":
                    return "bool";

                default:
                    return "unknow";
            }
        }

        private string PropertyTypeExtensionToSqlType(Type propertyType)
        {
            switch (propertyType.ToString().Replace("System.", "").ToLower())
            {
                case "string":
                    return "nvarchar(***)";

                case "datetime":
                    return "datetime";

                case "int32":
                    return "int";

                case "int64":
                    return "bigint";

                case "decimal":
                    return "decimal(16,4)";

                case "boolean":
                    return "bit";

                default:
                    return "unknow";
            }
        }
    }
}