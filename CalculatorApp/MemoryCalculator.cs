using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class MemoryCalculator : ICalculator
    {
        private ICalculator _calculator;

        private double? _lastResult;

        private Dictionary<uint, double> memorySlotToValueLookup = new Dictionary<uint, double>();

        public MemoryCalculator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public double? Process(string input, out string message)
        {
            input = Input.RemoveExtraSpaces(input);


            if (input.StartsWith("X", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("M".Length);
                uint slotNumber = uint.Parse(number);

                if (memorySlotToValueLookup.TryGetValue(slotNumber, out double result))
                {
                    message = null;
                    _lastResult = result;
                    return result;
                }
                throw new KeyNotFoundException($"Memory slot {slotNumber} does not contain a value.");
            }
            // save M1
            else if (input.StartsWith("save M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("save M".Length);
                uint slotNumber = uint.Parse(number);

                if (_lastResult != null)
                {
                    message = $"Saved value {_lastResult} into memory slot {slotNumber}.";
                    memorySlotToValueLookup[slotNumber] = _lastResult.Value;
                    return _lastResult;
                }
                throw new InvalidOperationException("The value already exists.");
            }
            // input clear M1
            else if (input.StartsWith("clear M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("clear M".Length);
                uint slotNumber = uint.Parse(number);

                if (memorySlotToValueLookup.Remove(slotNumber, out double result))
                {
                    message = $"Memory slot {slotNumber} has been cleared.";
                    _lastResult = result;
                    return result;
                }
                throw new KeyNotFoundException($"Memory slot {slotNumber} does not exist.");
            }
            // clear all slots
            else if (input == "clear all")
            {
                message = $"Cleared all memory slots.";
                memorySlotToValueLookup.Clear();
                return null;
            }
            else
            {
                ReplaceMemoryValues(input);
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
        }

        public string ReplaceMemoryValues(string input)
        {
            int mIndex = input.IndexOf('M');
            int slotNumberIndex = mIndex + 1;
            int slotNumberLength = CountConsecutiveDigits(input, slotNumberIndex);
            var slotNumberString = input.Substring(slotNumberIndex, slotNumberLength);
            var slotNumber = uint.Parse(slotNumberString);

            var storedValue = memorySlotToValueLookup[slotNumber];
            string beforeSlot = input.Substring(0, mIndex);
            string afterSlot = input.Substring(slotNumberIndex + slotNumberLength);
            input = beforeSlot + storedValue + afterSlot;

            return input;
        }

        private static int CountConsecutiveDigits(string s, int startIndex)
        {
            var count = 0;
            for (int i = startIndex; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}
