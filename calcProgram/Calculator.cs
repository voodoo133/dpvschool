using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace calcProgram
{
    public class Calculator 
    {
        public bool error = false;
        public string errorMessage = "";
        public float? result = null;
        private string expression = "";

        public Calculator (string expression)
        {
            this.expression = expression;

            this.checkExpression();
        }

        public void exec() 
        {
            if (!this.error) {
                string[] parts = this.expression.Split(new Char[] { ' ' });

                var ci = new CultureInfo("ru-RU");

                float operand1 = Single.Parse(Regex.Replace(parts[0], @"\.", ","), ci.NumberFormat);
                float operand2 = Single.Parse(Regex.Replace(parts[2], @"\.", ","), ci.NumberFormat);

                switch(parts[1]) {
                    case "+": 
                        this.result = operand1 + operand2;

                        break;

                    case "-": 
                        this.result = operand1 - operand2;

                        break;

                    case "*": 
                        this.result = operand1 * operand2;

                        break;

                    case "/": 
                        this.result = operand1 / operand2;

                        break;        

                    default:
                        this.error = true;
                        this.errorMessage = "Неизвестный оператор";

                        break;
                }
            }
        }

        private void checkExpression ()
        {
            if (!Regex.IsMatch(this.expression, @"^\-?\d{1,}([,.]\d{1,})?\s{1}[+\-*/]{1}\s{1}\-?\d{1,}([,.]\d{1,})?$"))
            {
                this.error = true;
                this.errorMessage = "Неверный формат выражения";
            }
        }
    }
}