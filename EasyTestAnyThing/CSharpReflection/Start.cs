using EasyTestAnyThing.CSharpReflection.Api;
using EasyTestAnyThing.CSharpReflection.Api.Model;
using EasyTestAnyThing.CSharpReflection.Factory;
using System;
using System.Linq;

namespace EasyTestAnyThing.CSharpReflection
{
    public static class Start
    {
        /*
         * 練習 C#反射
         * 大致流程為 
         *  New NewApi 並且 該 NewApi 建構式需要參數
         *  而建構式的參數 由反射去尋找
         *  反射取得參數的過程中
         *  如果找不到該參數會出錯誤
         * -
         * StartNotSimplifyMethod 為尚未簡化流程
         * StartSimplifyMethod 為簡化流程
         */

        /// <summary>
        /// 尚未簡化反射流程
        /// </summary>
        public static void StartNotSimplifyMethod()
        {
            //取出該API的建構參數名稱
            var getConstructorsParameterProperties = typeof(NewApi)
                .GetConstructors().First()  //拿該Class的第一個建構子後
                .GetParameters().First()    //拿該建構子的第一個參數
                .ParameterType              //取得第一個參數的Type
                .GetProperties();           //找該Type的公用屬性

            //從DB找到 該API建立參數的值
            var parameter = new NewApiParameter();
            getConstructorsParameterProperties.ToList()
                .ForEach(f => parameter
                              .GetType()
                              .GetProperty(f.Name)
                              .SetValue(parameter, GetApiParameterFactory.GetParameter(f.Name)));

            Console.WriteLine(new NewApi(parameter).GetGameUrl()); 
        }

        /// <summary>
        /// 簡化版反射流程
        /// </summary>
        public static void StartSimplifyMethod()
        {
            Console.WriteLine(ReflectionFactory.BuildClass<NewApi>().GetGameUrl());
        }
    }
}