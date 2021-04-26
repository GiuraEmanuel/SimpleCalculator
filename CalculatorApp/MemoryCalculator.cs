using System;
using System.Collections.Generic;
using System.Linq;

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
                var number = input.Substring("save M".Length);
                uint slotNumber = uint.Parse(number);

                memorySlotToValueLookup.Add(slotNumber, _lastResult);

                message = $"Saved value {_lastResult} into memory slot {slotNumber}.";
                return _lastResult;
            }
            // input clear M1
            else if (input.StartsWith("clear M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("clear M".Length);
                uint slotNumber = uint.Parse(number);

                var result = memorySlotToValueLookup[slotNumber] = 0;

                message = $"Slot M{slotNumber} has been cleared.";
                return result;
            }
            // clear all slots
            else if (input == "clear all" && memorySlotToValueLookup.Count == 0)
            {
                memorySlotToValueLookup.Clear();
                message = "Cleared all memory slots.";
                return memorySlotToValueLookup.Count;
            }
            else
            {
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
        }
    }
}
