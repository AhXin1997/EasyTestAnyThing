using System;
using System.Collections.Generic;
using System.Linq;

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

            list.ForEach(Console.WriteLine);
            Console.ReadKey();
        }

        private const string Accessors = "{get; set;}";

        private void ToAccessors(List<string> list)
        {
            list.AddRange(
                typeof(Item)
                    .GetProperties()
                    .Select(index =>
                        $"public {PropertyTypeExtensionToAccessors(index.PropertyType)} {index.Name} " + Accessors
                        )
                );
        }

        private void ToSql(List<string> list)
        {
            list.Add("Name\tType\tAllow Null");
            list.AddRange(
                typeof(Item)
                    .GetProperties()
                    .Select(index => 
                        $"{index.Name}\t{PropertyTypeExtensionToSqlType(index.PropertyType)}\t" + ","
                        )
                );
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
                    return "unknown";
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
                    return "unknown";
            }
        }
    }
}