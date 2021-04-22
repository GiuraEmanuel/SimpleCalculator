using System;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        public double Process(string input, out string message)
        {
            input = PrepareInput(input);
            char[] operatorsArray = { '+', '~', '/', 'x' };
            var operatorIndex = input.IndexOfAny(operatorsArray);

            double result = 0;
            if (operatorIndex == -1)
            {
                result = double.Parse(input);
            }
            else
            {
                var mathOperator = input[operatorIndex];

                string[] values = input.Split(mathOperator);

                if (values.Length != 2)
                {
                    throw new FormatException("Please provided 2 values.");
                }

                var firstValueParsed = double.Parse(values[0]);
                var secondValueParsed = double.Parse(values[1]);

                switch (mathOperator)
                {
                    case '+':
                        result = firstValueParsed + secondValueParsed;
                        break;

                    case '~':
                        result = firstValueParsed - secondValueParsed;
                        break;

                    case '/':
                        if (secondValueParsed == 0)
                        {
                            throw new DivideByZeroException("Division by 0 is not allowed.");
                        }

                        result = firstValueParsed / secondValueParsed;
                        break;

                    case 'x':
                        result = firstValueParsed * secondValueParsed;
                        break;
                }
            }
            message = "Result: " + result;
            return result;
        }

        private static string PrepareInput(string input)
        {
            input = Input.RemoveExtraSpaces(input);

            if (input.Length < 1)
            {
                throw new FormatException("Input cannot be empty.");
            }

            var index = input.IndexOf('-', 1);

            if (MinusReplacementIsNeeded(input, index))
            {
                var inputArray = input.ToCharArray();
                inputArray[index] = '~';

                input = new string(inputArray);
            }
            return input;
        }

        

        private static bool MinusReplacementIsNeeded(string input, int index)
        {
            if (index >= 0 && (input[index - 1] == '.' || char.IsDigit(input[index - 1])))
                return true;

            return index >= 2 && input[index - 1] == ' ' && (input[index - 2] == '.' || char.IsDigit(input[index - 2]));
        }
    }
}
