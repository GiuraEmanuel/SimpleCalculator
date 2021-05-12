using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApp
{
    public class Calculator : ICalculator
    {
        private Dictionary<char, Func<double, double, double>> _operatorToOperationLookup = new();

        public void RegisterOperator(char op, Func<double, double, double> operation)
        {
            // 1. Validate parameters
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }
            if (!char.IsLetter(op) && !char.IsSymbol(op) && op!= '/')
            {
                throw new ArgumentException("Operator must be a symbol or a letter.", nameof(op));
            }
            // 2. Add operation to dictionary
            _operatorToOperationLookup.Add(op, operation);
        }

        public Calculator()
        {
            RegisterOperator('+', (v1, v2) => v1 + v2);
            RegisterOperator('~', (v1, v2) => v1 - v2);
            RegisterOperator('x', (v1, v2) => v1 * v2);
            RegisterOperator('/', (v1, v2) =>
            {
                if (v2 == 0)
                {
                    throw new DivideByZeroException("Division by 0 is not allowed.");
                }
                return v1 / v2;
            });
        }


        public double? Process(string input, out string message)
        {
            input = PrepareInput(input);
            char[] operatorsArray = _operatorToOperationLookup.Keys.ToArray();
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

                var operation = _operatorToOperationLookup[mathOperator];
                result = operation.Invoke(firstValueParsed, secondValueParsed);
            }
            message = null;
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
