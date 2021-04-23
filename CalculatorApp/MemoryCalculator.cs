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
            //save M5
            input = Input.RemoveExtraSpaces(input);

            var number = input.Substring("M".Length);

            if (input.StartsWith("save M", StringComparison.OrdinalIgnoreCase))
            {
                var numberFromString = input.Substring("save M".Length);

                uint slotNumber = uint.Parse(numberFromString);

                memorySlotToValueLookup.Add(slotNumber, _lastResult);

                // [set the message and return the appropriate result here]
                message = $"Saved value {_lastResult} into memory slot 1.";
            }
            else if (input.StartsWith("M", StringComparison.OrdinalIgnoreCase))
            {
                if (memorySlotToValueLookup.ContainsKey(uint.Parse(number)))
                {
                    message = $"M{number}" + _lastResult;
                    return _lastResult;
                }
            }
            else
            {
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
            message = $"Saved value {_lastResult} into memory slot 1.";
            return _lastResult;
        }
    }
}
