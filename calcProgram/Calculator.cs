using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;

namespace calcProgram
{
    public class Calculator 
    {
        public string result = "";

        public bool stop = false;

        private List<string> history = new List<string>() {};

        public Calculator ()
        {
            
        }

        public void exec(string expression) 
        {
            if (this.isCalculatedExpression(expression)) {
                this.result = this.calculate(expression);
            } else {
                switch (expression)
                {
                    case "show history": 
                        this.result = this.getHistory();

                        break;
                    
                    case "exit":
                        this.stop = true;
                        this.result = "Пока";

                        break;

                    default:
                        this.result = "Неизвестная команда";

                        break;
                }
            }
        }

        private bool isCalculatedExpression (string expression)
        {
            return Regex.IsMatch(expression, @"^\-?\d{1,}([,.]\d{1,})?\s{1}[+\-*/]{1}\s{1}\-?\d{1,}([,.]\d{1,})?$");
        }

        private string calculate (string expression)
        {
            string[] parts = expression.Split(new Char[] { ' ' });

            var ci = new CultureInfo("ru-RU");

            float operand1 = Single.Parse(Regex.Replace(parts[0], @"\.", ","), ci.NumberFormat);
            float operand2 = Single.Parse(Regex.Replace(parts[2], @"\.", ","), ci.NumberFormat);
            string operation = parts[1];
            float? result = 0;

            string error = "";

            switch(operation) {
                case "+": 
                    result = operand1 + operand2;

                    break;

                case "-": 
                    result = operand1 - operand2;

                    break;

                case "*": 
                    result = operand1 * operand2;

                    break;

                case "/": 
                    if (operand2 == 0) {
                        error = "Опасная операция деления на ноль!";
                    } else {
                        result = operand1 / operand2;
                    }
                    
                    break;

                default:
                    error = "Неизвестный оператор";

                    break;
            }

            if (String.IsNullOrEmpty(error)) {
                string successfulOperation = $"{operand1} {operation} {operand2} = {result}";
                this.history.Add(successfulOperation);

                return result.ToString();
            } else {
                return error;
            }
        }

        private string getHistory ()
        {
            string result = "История ваших операций: \r\n";

            if (this.history.Count == 0) {
                result = "Не было произведено ни одной операции\r\n";
            } else {
                this.history.ForEach(delegate(String historyItem) {
                    result += historyItem + "\r\n";
                });
            }

            result += "-------------------------------";

            return result;
        }
    }
} 