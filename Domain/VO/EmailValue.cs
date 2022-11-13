using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.VO
{
    public class EmailValue
    {
            [EmailAddress]
            public string Value { get; private set; }

            public EmailValue(string value)
            {
                Value = value;
                validate();
            }
        public void validate()
        {
            Regex regex = new Regex(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*)+$");
            if (!regex.IsMatch(Value))
            {
                throw new Exception ("Invalid email: value must be a valid email.");
            }
        }
    }
}
