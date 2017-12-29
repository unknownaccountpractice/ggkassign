using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatOperations
{
    class BinaryConverter
    {
        internal string FloatToBinary(float input)
        {
            string result = "";
            int integer = (int)input;
            float fraction = input - integer;
            result += IntegerToBinary(integer);
            result += ".";
            result += FractionToBinary(fraction);
            return result;
        }
        internal float BinaryToFloat(ArrayList binary, int decimalPointPosition)
        {
            StringBuilder decimalBinary = new StringBuilder("");
            StringBuilder fractionBinary = new StringBuilder("");
            for (int i = 0; i < binary.Count; i++)
            {
                if (i < decimalPointPosition)
                {
                    decimalBinary.Append(binary[i]);
                 //   Console.WriteLine("db "+binary[i]);
                }
                else
                {
                    fractionBinary.Append(binary[i]);
                  //  Console.WriteLine("fb " + binary[i]);
                }
            }
            return BinaryToInteger(decimalBinary) + BinaryToFraction(fractionBinary);
        }

        string IntegerToBinary(int input)
        {
            StringBuilder result = new StringBuilder("");
            while (input != 0)
            {
                result.Insert(0,input % 2);
                input = input / 2;
            }
            return result.ToString();
        }
         string FractionToBinary(float input)
        {
            StringBuilder result = new StringBuilder("");
            for(int i=0;i<1000 && input != 0; i++)
            {
                int remainder = (int)(2 * input);
                result.Append(remainder);
                input = 2 * input - remainder;
            }
            return result.ToString();
        }
         int BinaryToInteger(StringBuilder input)
        {
            int result = 0;
            for(int i = input.Length - 1; i > -1; i--)
            {
                char c = input[i];
                if (c == '1')
                    result = result + (int)Math.Pow(2, input.Length - 1 - i);
            }
            return result;
        }
         float BinaryToFraction(StringBuilder input)
        {
            float result = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i]=='1')
                result = result + (float)Math.Pow(2, -i-1);
            }
            return result;
        }
    }
}
