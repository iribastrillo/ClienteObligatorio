using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VO
{
    public class PositiveIntegerValue
    {
        public int Value { get; private set; }

        public PositiveIntegerValue(int value)
        {
            Value = value;
            validate();
        }
        public void validate()
        {
            if (Value < 0)
            {
                throw new Exception("Invalid Integer: value must be a positive integer.");
            }
        }
    }
}
