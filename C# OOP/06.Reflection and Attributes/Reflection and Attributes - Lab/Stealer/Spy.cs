using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo
            (string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields =
                classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object createInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classType.FullName}");

            foreach (var item in classFields.Where(x => requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(createInstance)}");
            }
            return sb.ToString().TrimEnd();

        }
        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            FieldInfo[] publicField = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethod = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] publicMethod = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in publicField)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in privateMethod.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in publicMethod.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethod(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] allPrivateMethod = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            sb.AppendLine($"All Private Methods of Class: {typeOfClass.FullName}");
            sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

            foreach (var item in allPrivateMethod)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        }
        public string GetAllMethodsAndRecognize(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] allMethods = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var item in allMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} will return {item.ReturnType.FullName}");
            }
            foreach (var item in allMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} set field of {item.GetParameters().First().ParameterType}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}