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

            if (input.StartsWith("save M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("save M".Length);
                uint slotNumber = uint.Parse(number);

                if (_lastResult != null)
                {
                    message = $"Saved value {_lastResult} into memory slot {slotNumber}.";
                    memorySlotToValueLookup[slotNumber] = _lastResult.Value;
                    return _lastResult;
                }   
                throw new InvalidOperationException("There is no previous result to store.");
            }
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
            else if (input == "clear all")
            {
                message = $"Cleared all memory slots.";
                memorySlotToValueLookup.Clear();
                return null;
            }
            else
            {
                input = ReplaceMemoryValues(input);
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
        }

        public string ReplaceMemoryValues(string input)
        {
            int mIndex = input.IndexOf('M',StringComparison.OrdinalIgnoreCase);
            while (mIndex >= 0)
            {
                int slotNumberIndex = mIndex + 1;
                int slotNumberLength = CountConsecutiveDigits(input, slotNumberIndex);
                var slotNumberString = input.Substring(slotNumberIndex, slotNumberLength);
                var slotNumber = uint.Parse(slotNumberString);

                if (!memorySlotToValueLookup.TryGetValue(slotNumber, out double value))
                {
                    throw new KeyNotFoundException($"Memory slot {slotNumber} does not exist.");
                }
                    
                string beforeSlot = input.Substring(0, mIndex);
                string afterSlot = input.Substring(slotNumberIndex + slotNumberLength);
                input = beforeSlot + value + afterSlot;
                mIndex = input.IndexOf('M', StringComparison.OrdinalIgnoreCase);
            }
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

        public void DisplaySlots()
        {
            foreach (var slot in memorySlotToValueLookup.Keys)
            {
                Console.WriteLine($"Slot {slot} : {memorySlotToValueLookup[slot]}");
            }
        }
    }
}
