using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var homework = new HomeWork();
            var result = homework.InvokePriceCalculatiion();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
