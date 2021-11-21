using System;
using System.Diagnostics;

namespace ConsoleApp21
{

    public class First
    {
        public virtual void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Class First has no properties");
        }
    }
    public class Second : First
    {
        public string Name { get; set; } = "";

        public Second(string name)
        {
            Name = name;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Second class properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Name)}: {Name}");
            Debug.Unindent();
        }
    }
    public class Third : First
    {
        public DateTime TimeOfCreation { get; }

        public Third()
        {
            TimeOfCreation = DateTime.Now;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Third class properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(TimeOfCreation)}: {TimeOfCreation}");
            Debug.Unindent();
        }
    }
    public class Fouth : First
    {
        public uint Id { get; }

        private static uint LastId = 0;

        public Fouth()
        {
            Id = ++LastId;
        }

        public override void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Fouth class properties:");
            Debug.Indent();
            Debug.WriteLine($"{nameof(Id)}: {Id}");
            Debug.Unindent();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            var B = new Second("third class");
            var C = new Third();
            var D = new Fouth();




            B.PrintPropertiesToDebug();
            C.PrintPropertiesToDebug();
            D.PrintPropertiesToDebug();
            Console.ReadLine();
        }
    }
}