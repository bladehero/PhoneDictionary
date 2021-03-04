using System.Reflection;

namespace PhoneDictionary.CQRS
{
    public class AssemblyInfo
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetAssembly(typeof(AssemblyInfo));
        }
    }
}