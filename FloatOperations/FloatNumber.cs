using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatOperations
{
    internal class FloatNumber
    {
        internal float number;

        internal Boolean isPositive;
        internal FloatNumber(float value)
        {
            number = value;
            if (value >= 0)
            {
                isPositive = true;
            }
            else
            {
                number = Math.Abs(number);
                isPositive = false;
            }

        }
        public static FloatNumber operator *(FloatNumber firstInput, FloatNumber secondInput)
        {
            ArithmeticOperations arithmeticOperations = new ArithmeticOperations();
            FloatNumber result = arithmeticOperations.FloatMultiplication(firstInput, secondInput);

            return result;
        }
        public static FloatNumber operator +(FloatNumber firstInput, FloatNumber secondInput)
        {
            ArithmeticOperations arithmeticOperations = new ArithmeticOperations();
            FloatNumber result = arithmeticOperations.FloatAddition(firstInput, secondInput);
            return result;
        }
    }
}
