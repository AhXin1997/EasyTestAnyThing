using System;
using System.Linq;

namespace EasyTestAnyThing.Training.CSharpReflection.Factory
{
    public static class ReflectionFactory
    {
        //外面丟進來需要建立的Class
        public static T BuildClass<T>()
        {
            var parameterType = FindClassParameterType<T>();
            var newParameter = Activator.CreateInstance(parameterType);
            SetClassValue(parameterType, newParameter);
            return (T)Activator.CreateInstance(typeof(T), newParameter);
        }

        private static Type FindClassParameterType<T>()
        {
            return typeof(T)
                    .GetConstructors().First()
                    .GetParameters().First()
                    .ParameterType;
        }

        private static void SetClassValue(Type parameter, object targetClass)
        {
            if (targetClass != null)
            {
                throw new NullReferenceException();
            }
            parameter.GetProperties().ToList()
                    .ForEach(f => targetClass
                                  .GetType()
                                  .GetProperty(f.Name)
                                  .SetValue(targetClass, GetApiParameterFactory.GetParameter(f.Name)));
        }
    }
}