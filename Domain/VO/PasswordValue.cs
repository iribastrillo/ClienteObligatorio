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
            bool hasUppercase = false;
            bool hasLowerCase = false;
            bool hasExclamation = false;
            bool hasComma = false;
            bool hasDot = false;
            bool hasDigit = false;
            bool properLength = Value.Length >= 8;

            foreach (var c in Value)
            {
                if (Char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (Char.IsLower(c))
                {
                    hasLowerCase = true;
                }
                if (Char.IsUpper (c))
                {
                    hasUppercase = true;
                }
                if (c == '!')
                {
                    hasExclamation = true;
                } 
                if (c == '.')
                {
                    hasDot = true;
                }
                if (c == ',')
                {
                    hasComma = true;
                }
            }
            if (!properLength)
            {
                throw new Exception ("La contraseña debe tener al menos ocho caracteres");
            }
        }
    }
}
