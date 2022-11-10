using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VO
{
    public class PasswordValue
    {
        public string Value { get; private set; }

        public PasswordValue(string value)
        {
            Value = value;
            validate();
        }
        public void validate()
        {
        }
    }
}
