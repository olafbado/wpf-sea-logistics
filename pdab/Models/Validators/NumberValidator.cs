using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdab.Models.Validators
{
    public class NumberValidator:Validator
    {
        public static string CheckIfPositive(int value)
        {
            if (!value.GetType().IsPrimitive)
            {
                return "Value must be a number";
            }
            if (value < 0)
            {
                return "Value must be positive";
            }
            return null;
        }

        public static string CheckIfIsNumber(int value)
        {
            if (!value.GetType().IsPrimitive)
            {
                return "Value must be a number";
            }
            return null;
        }
    }
}
