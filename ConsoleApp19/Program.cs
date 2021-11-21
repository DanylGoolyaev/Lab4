using System;
using System.Diagnostics;

namespace ConsoleApp19
{
    public class FirstClass
    {
        public virtual void ShowInDebug(params object[] args)
        {
            Debug.Indent();
            Debug.WriteLine("Arguments:");
            Debug.WriteLine("");
            Debug.Unindent();

            foreach (var i in args)
            {
                Debug.WriteLine($"* {i}");
            }
            Debug.WriteLine("");
        }
    }
    public class SecondClass : FirstClass
    {
        public override void ShowInDebug(params object[] args)
        {
            Debug.Indent();
            Debug.WriteLine("Arguments in Second Class:");
            Debug.WriteLine("");
            Debug.Unindent();

            foreach (var i in args)
            {
                Debug.WriteLine($"* {i.GetType()}: {i}");
            }
            Debug.WriteLine("");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FirstClass[] classes = new[]
            {
                new FirstClass(),
                new SecondClass()
            };

            foreach (FirstClass test in classes)
                test.ShowInDebug(
                    DateTime.Now,
                    884555612,
                    1.547f,
                    16.53d,
                    11.42m,
                    new object(),
                    "Что-то"

                );

            Console.ReadLine();
        }
    }
}