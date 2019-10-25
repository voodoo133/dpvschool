using System;

namespace calcProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string greetingMsg = "Здравствуйте.\nВведите, пожалуйста, выражение в формате \"Число1 Оператор Число2\" (например, 1 + 2)\nВведите show history для просмотра операций\nВведите exit для выхода";
            Console.WriteLine(greetingMsg);

            var c = new Calculator();

            while (true) {
                string inputedStr = Console.ReadLine();
                inputedStr = inputedStr.Trim();

                c.exec(inputedStr);
                
                Console.WriteLine(c.result);

                if (c.stop) 
                    break;
            }
            
        }
    }
}
