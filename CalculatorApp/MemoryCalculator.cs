using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class MemoryCalculator : ICalculator
    {
        private ICalculator _calculator;

        private double _lastResult;

        private Dictionary<uint, double> memorySlotToValueLookup = new Dictionary<uint, double>();

        public MemoryCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public double Process(string input, out string message)
        {
            input = Input.RemoveExtraSpaces(input);

            if (input.StartsWith("M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("M".Length);
                uint slotNumber = uint.Parse(number);

                if (memorySlotToValueLookup.TryGetValue(slotNumber, out double result))
                {
                    message = "Result: " + result;
                    return result;
                }
                throw new KeyNotFoundException($"Memory slot {slotNumber} does not contain a value.");
            }

            else if (input.StartsWith("save M", StringComparison.OrdinalIgnoreCase))
            {
                var numberFromString = input.Substring("save M".Length);
                uint slotNumber = uint.Parse(numberFromString);

                memorySlotToValueLookup.Add(slotNumber, _lastResult);

                message = $"Saved value {_lastResult} into memory slot {slotNumber}.";
                return _lastResult;
            }
            else
            {
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
        }
    }
}
