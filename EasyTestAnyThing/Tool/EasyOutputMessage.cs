using System;
using System.Collections.Generic;
using System.Linq;
using EasyTestAnyThing.Tool.Enum;

namespace EasyTestAnyThing.Tool
{
    public static class EasyOutputMessage
    {
        public static void EasyOutputMessageMethod(this Type classType, EasyOutputMessageMethod method)
        {
            if (!classType.GetProperties().Any())
            {
                return;
            }
            ConverterTo(classType, method).ForEach(Console.WriteLine);
            Console.ReadKey();
        }

        private static List<string> ConverterTo(Type classType, EasyOutputMessageMethod type)
        {
            var list = new List<string>();

            if (type is Enum.EasyOutputMessageMethod.ToSqlTable)
            {
                list.Add("|Name|Type|Allow Null|");
                list.Add("|----|----|----------|");
            }

            list.AddRange(
                classType
                    .GetProperties()
                    .Select(index =>
                    {
                        switch (type)
                        {
                            case Enum.EasyOutputMessageMethod.ToSqlTable:
                                return $"|{index.Name}|{PropertyTypeExtensionToSqlType(index.PropertyType)}| not null,|";

                            case Enum.EasyOutputMessageMethod.ToClassProperty:
                                return $"public {PropertyTypeExtensionToAccessors(index.PropertyType)} {index.Name}  {{get; set;}}";

                            case Enum.EasyOutputMessageMethod.ToMultilingualKeysCode:
                                return $"new() {{ DisplayKey = MultilingualKeys.Raw_{classType.Name}_{index.Name}, Value = record.{index.Name} }},";

                            case Enum.EasyOutputMessageMethod.ToMultilingualKeysName:
                                return $"Raw_{classType.Name}_{index.Name},";

                            case Enum.EasyOutputMessageMethod.ToSqlDataModel:
                                return $"{index.Name} = rawData.{index.Name},";

                            case Enum.EasyOutputMessageMethod.ToCreateSqlParameter:
                                return $"{{nameof(betRaw.{index.Name}), betRaw.{index.Name}}},";

                            default:
                                throw new ArgumentOutOfRangeException(nameof(type), type, null);
                        }
                    })
                );

            return list;
        }
        
        private static string PropertyTypeExtensionToAccessors(Type propertyType)
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

        private static string PropertyTypeExtensionToSqlType(Type propertyType)
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