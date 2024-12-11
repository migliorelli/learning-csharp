

using System;

namespace MyFirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.Write("What's your name? ");
            string name = Console.ReadLine();

            Console.Write("How old are you? ");
            string ageStr = Console.ReadLine();
            int age = Convert.ToInt32(ageStr);

            Console.WriteLine($"Your name is {name} and you are {age} years old.");


        }
    }
}
