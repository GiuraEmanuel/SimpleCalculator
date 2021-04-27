﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            if (input.StartsWith("M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("M".Length);
                uint slotNumber = uint.Parse(number);

                if (memorySlotToValueLookup.TryGetValue(slotNumber, out double result))
                {
                    message = "Result: " + result;
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

                if (_lastResult !=null)
                {
    
                   memorySlotToValueLookup.Add(slotNumber, _lastResult.Value);
                }

                message = $"Saved value {_lastResult} into memory slot {slotNumber}.";
                return _lastResult;
            }
            // input clear M1
            else if (input.StartsWith("clear M", StringComparison.OrdinalIgnoreCase))
            {
                var number = input.Substring("clear M".Length);
                uint slotNumber = uint.Parse(number);

                if (memorySlotToValueLookup.Remove(slotNumber, out double result))
                {
                    message = $"Slot M{slotNumber} has been cleared.";
                    _lastResult = result;
                    return result;
                }
                throw new KeyNotFoundException($"Memory slot {slotNumber} does not exist.");
            }
            // clear all slots
            else if (input == "clear all")
            {
                message = $"Cleared all {memorySlotToValueLookup.Count} memory slots.";
                memorySlotToValueLookup.Clear();
                return null;
            }
            else
            {
                _lastResult = _calculator.Process(input, out message);
                return _lastResult;
            }
        }
    }
}
