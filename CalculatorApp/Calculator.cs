using System;

namespace CalculatorApp
{
    public class Calculator
    {

        public double Process(string input, out string message)
        {
            input = PrepareInput(input);
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

            if (secondValueParsed == 0 && mathOperator == operatorsArray[2])
            {
                throw new DivideByZeroException("Division by zero is not accepted.");
            }

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

        private static string PrepareInput(string input)
        {
            input = input.Replace(" ", "");

            if (input.Length < 1)
            {
                throw new FormatException("Input cannot be empty.");
            }

            var index = input.IndexOf('-', 1);

            if (index >= 0 && (input[index - 1] == '.' || char.IsDigit(input[index - 1])))
            {
                var inputArray = input.ToCharArray();
                inputArray[index] = '~';

                input = new string(inputArray);
            }
            return input;
        }
    }
}
