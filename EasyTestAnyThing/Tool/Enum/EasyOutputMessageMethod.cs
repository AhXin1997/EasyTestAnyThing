namespace EasyTestAnyThing.Tool.Enum
{
    public enum EasyOutputMessageMethod
    {
        /// <summary>
        /// |{index.Name}|{PropertyTypeExtensionToSqlType(index.PropertyType)}| not null,|
        /// </summary>
        ToSqlTable,

        /// <summary>
        /// public {PropertyTypeExtensionToAccessors(index.PropertyType)} {index.Name} {get; set;}
        /// </summary>
        ToClassProperty,

        /// <summary>
        /// new() { DisplayKey = MultilingualKeys.Raw_{nameof(classType)}_{index.Name}, Value = record.{index.Name} },
        /// </summary>
        ToMultilingualKeysCode,

        /// <summary>
        /// Raw_{nameof(classType)}_{index.Name},
        /// </summary>
        ToMultilingualKeysName,

        /// <summary>
        /// {index.Name} = rawData.{index.Name},
        /// </summary>
        ToSqlDataModel,

        /// <summary>
        /// {nameof(betRaw.{index.Name}), betRaw.{index.Name}},
        /// </summary>
        ToCreateSqlParameter
    }
}