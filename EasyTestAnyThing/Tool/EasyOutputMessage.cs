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
                                return $"new() {{ DisplayKey = MultilingualKeys.Raw_{classType.Name}_{index.Name}, Value = {string.Format(PropertyTypeExtensionToMultilingualValue(index.PropertyType), $"record.{index.Name}")} }},";

                            case Enum.EasyOutputMessageMethod.ToMultilingualKeysName:
                                return $"Raw_{classType.Name}_{index.Name},";

                            case Enum.EasyOutputMessageMethod.ToSqlDataModel:
                                return $"{index.Name} = rawData.{index.Name},";

                            case Enum.EasyOutputMessageMethod.ToCreateSqlParameter:
                                return $"{{nameof(betRaw.{index.Name}), betRaw.{index.Name}}},";
                            
                            case Enum.EasyOutputMessageMethod.ToSqlMapping:
                                return $"Property(p => p.{index.Name}){PropertyTypeExtensionToSqlMapping(index.PropertyType)}.IsRequired();";

                            default:
                                throw new ArgumentOutOfRangeException(nameof(type), type, null);
                        }
                    })
                );

            if (type is Enum.EasyOutputMessageMethod.ToSqlTable)
            {
                list.Insert(0, "|Name|Type|Allow Null|");
                list.Insert(0, "|----|----|----------|");
            }
            
            if (type is Enum.EasyOutputMessageMethod.ToSqlMapping)
            {
                list.Insert(0, "HasKey(x => x.Id);");
                list.Add($"ToTable(\"TableName\");");
            }




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
                    return "nvarchar(WordCount)";

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
        
        private static string PropertyTypeExtensionToMultilingualValue(Type propertyType)
        {
            switch (propertyType.ToString().Replace("System.", "").ToLower())
            {
                case "string":
                    return "{0}";

                case "datetime":
                    return "FormatTimeToSecond({0})";

                case "decimal":
                    return "FormatDecimal({0})";

                case "boolean":
                    return "FormatBoolean({0})";

                default:
                    return "{0}.ToString()";
            }
        }
        
        private static string PropertyTypeExtensionToSqlMapping(Type propertyType)
        {
            switch (propertyType.ToString().Replace("System.", "").ToLower())
            {
                case "string":
                    return ".HasMaxLength(100)";
                default:
                    return string.Empty;
            }
        }
    }
}