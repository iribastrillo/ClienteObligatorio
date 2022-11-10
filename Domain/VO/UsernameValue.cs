using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VO
{
    public class UsernameValue
    {
        public string Value { get; private set; }

        public UsernameValue(string value)
        {
            Value = value;
            validate();
        }
        public void validate()
        {
            if (String.IsNullOrEmpty(Value))
            {
                throw new Exception("Invalid name: name must not be null or empty.");
            }
            if (String.IsNullOrWhiteSpace(Value))
            {
                throw new Exception("Invalid name: name must not consist only of white-space characters.");
            }
            if (Value[0] == ' ' || Value[Value.Length - 1] == ' ')
            {
                throw new Exception("Invalid name: name must not containt whitespaces at the beginning or the end.");
            }
        }
    }
}
