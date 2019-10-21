using System;

namespace calcProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте. Введите, пожалуйста, выражение в формате \"Число1 Оператор Число2 (например, 1 + 2)\"");

            string inputedStr = Console.ReadLine();
            inputedStr = inputedStr.Trim();

            var c = new Calculator(inputedStr);

            c.exec();

            if (c.error) {
                Console.WriteLine(c.errorMessage);
            } else {
                Console.WriteLine(c.result);
            }
        }
    }
}
