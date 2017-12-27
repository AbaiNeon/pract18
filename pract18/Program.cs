using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace pract18
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskOne();
            //TaskTwo();

            Console.ReadLine();
        }

        private static void TaskOne()
        {
            int length = 3;
            
            try
            {
                Assembly asm = Assembly.LoadFrom(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\mscorlib.dll");

                Type t = asm.GetType("System.String", true, true);

                // создаем экземпляр класса 
                object obj = Activator.CreateInstance(t, "Hello".ToCharArray());
                
                // получаем метод Substring
                MethodInfo method = t.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

                // вызываем метод, передаем ему значения для параметров и получаем результат
                object result = method.Invoke(obj, new object[] { 2, length });
                Console.WriteLine((result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TaskTwo()
        {
            Type myType = typeof(List<Int32>);

            Console.WriteLine("Конструкторы:");
            foreach (ConstructorInfo ctor in myType.GetConstructors())
            {
                Console.Write(myType.Name + " (");
                // получаем параметры конструктора
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
    }
}