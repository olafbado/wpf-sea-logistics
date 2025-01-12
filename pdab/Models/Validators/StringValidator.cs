using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdab.Models.Validators
{
    internal class StringValidator : Validator
    {
        public static string CheckIfStartsWithCapitalLetter(string value)
        {

            // check if is empty or null
            if (string.IsNullOrWhiteSpace(value))
            {
                return "Value cannot be empty";
            }
            if (!char.IsUpper(value, 0))
            {
                return "Value must start with capital letter";
            }
            return null;
        }
    }
}
