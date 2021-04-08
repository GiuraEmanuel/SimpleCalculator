using System;

namespace CalculatorApp
{
    public class Calculator
    {
        public double Process(string input, out string message)
        {
            char[] operatorsArray = { '+', '~', '/', 'x' };
            var operatorIndex = input.IndexOfAny(operatorsArray);

            var mathOperator = input[operatorIndex];

            if (operatorIndex == -1)
            {
                throw new FormatException("Missing a valid operator");
            }

            string[] values = input.Split(mathOperator);

            if (values.Length != 2)
            {
                throw new FormatException("Please provided 2 values.");
            }

            var firstValueParsed = double.Parse(values[0]);
            var secondValueParsed = double.Parse(values[1]);



            double result = 0;

            switch (mathOperator)
            {
                case '+':
                    result = firstValueParsed + secondValueParsed;
                    break;

                case '~':
                    result = firstValueParsed - secondValueParsed;
                    break;

                case '/':
                    result = firstValueParsed / secondValueParsed;
                    break;

                case 'x':
                    result = firstValueParsed * secondValueParsed;
                    break;
            }
            message = "Result: " + result;
            return result;
        }
    }
}
