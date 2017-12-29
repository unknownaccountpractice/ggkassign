using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace FloatOperations
{
    class ArithmeticOperations
    {
        internal FloatNumber FloatAddition(FloatNumber firstInput, FloatNumber secondInput)
        {
            BinaryConverter binaryConverter = new BinaryConverter();
            String firstInputBinary = binaryConverter.FloatToBinary(firstInput.number);
            String secondInputBinary = binaryConverter.FloatToBinary(secondInput.number);
            float value = 0;
            int firstInputDecimalPointPosition = firstInputBinary.IndexOf('.');           
            int secondInputDecimalPointPosition = secondInputBinary.IndexOf('.');
            int carry = 0;
            String[] firstInputBinaryParts = firstInputBinary.Split('.');
            String[] secondInputBinaryParts = secondInputBinary.Split('.');
            ArrayList FSum = FloatSum(firstInputBinaryParts[1], secondInputBinaryParts[1], out carry);
            ArrayList Intsum = IntegerSum(firstInputBinaryParts[0], secondInputBinaryParts[0],carry);
            int binaryPosition = Intsum.Count;
            //Intsum.Add('.');
            Intsum.AddRange(FSum);
            //foreach(var x in Intsum){
            //    Console.Write(x);
           // }
            value = binaryConverter.BinaryToFloat(Intsum, binaryPosition);
            Console.WriteLine();
        return new FloatNumber(value);
        }
        ArrayList FloatSum(String first,String second,out int carry)
        {
            carry = 0;
            ArrayList sum = new ArrayList();
            int firstLength = first.Length;
            int secondLength = second.Length;
            int firstPosition = firstLength - 1;
            int secondPosition = secondLength - 1;
            for(int i = 0; i < Math.Max(firstLength, secondLength); i++)
            {
                if(firstPosition==secondPosition)
                {
                    if (carry == 1)
                    {
                        if (first[firstPosition] == '1' && second[secondPosition] == '1')
                        {
                            sum.Add(1);
                            carry = 1;
                        }
                        else
                        {
                            if (first[firstPosition] == '0' && second[secondPosition] == '0')
                            {
                                sum.Add(1);
                                carry = 0;
                            }
                            else
                            {
                                sum.Add(0);
                                carry = 1;
                            }
                        }

                    }
                    else
                    {
                        if (first[firstPosition] == '1' && second[secondPosition] == '1')
                        {
                            sum.Add(0);
                            carry = 1;
                        }
                        else
                        {
                            if (first[firstPosition] == '0' && second[secondPosition] == '0')
                            {
                                sum.Add(0);
                                carry = 0;
                            }
                            else
                            {
                                sum.Add(1);
                                carry = 0;
                            }
                        }
                    }
                    firstPosition--;
                    secondPosition--;
                }
                else
                {
                    if (firstPosition > secondPosition)
                    {
                        sum.Add(first[firstPosition]);
                        firstPosition--;
                    }
                    else
                    {
                        sum.Add(second[secondPosition]);
                        secondPosition--;
                    }
                }
            }
            sum.Reverse();
            return sum;

        }
        private ArrayList IntegerSum(String first,String second,int carry)
        {
            ArrayList sum = new ArrayList();
            int firstLength = first.Length;
            int secondLength = second.Length;
            int firstPosition = firstLength-1;
            int secondPosition = secondLength-1;
            
            for(int i = 0; i < Math.Max(firstLength, secondLength); i++,firstPosition--,secondPosition--)
            {
                if(firstPosition>-1 && secondPosition > -1)
                {
                    if (carry == 1)
                    {
                        if (first[firstPosition] == '1' && second[secondPosition] == '1')
                        {
                            sum.Add(1);
                            carry = 1;
                        }
                        else
                        {
                            if (first[firstPosition] == '0' && second[secondPosition] == '0')
                            {
                                sum.Add(1);
                                carry = 0;
                            }
                            else
                            {
                                sum.Add(0);
                                carry = 1;
                            }
                        }

                    }
                    else
                    {
                        if (first[firstPosition] == '1' && second[secondPosition] == '1')
                        {
                            sum.Add(0);
                            carry = 1;
                        }
                        else
                        {
                            if (first[firstPosition] == '0' && second[secondPosition] == '0')
                            {
                                sum.Add(0);
                                carry = 0;
                            }
                            else
                            {
                                sum.Add(1);
                                carry = 0;
                            }
                        }
                    }
                    
                }
                else
                {
                    if(firstPosition>-1 && secondPosition < 0)
                    {
                        if (carry == 1)
                        {
                            if (first[firstPosition] == '1')
                            {
                                carry = 0;
                                sum.Add(1);
                            }
                            else
                            {
                                carry = 0;
                                sum.Add(1);
                            }
                        }
                        else
                        {
                            sum.Add(Int32.Parse(first[firstPosition] + ""));
                        }
                    }
                    else
                    {
                        if(firstPosition <= -1 && secondPosition >= 0)
                        {
                            if (carry == 1)
                            {
                                if (second[secondPosition] == '1')
                                {
                                    carry = 0;
                                    sum.Add(1);
                                }
                                else
                                {
                                    carry = 0;
                                    sum.Add(1);
                                }
                            }
                            else
                            {
                                sum.Add(Int32.Parse(second[secondPosition] + ""));
                            }
                        }
                    }
                }
                
            }
            if (carry == 1)
            {
                sum.Add(1);
            }
            sum.Reverse();
            return sum;
        }
        internal FloatNumber FloatMultiplication(FloatNumber firstInput,FloatNumber secondInput)
        {
            BinaryConverter binaryconverter = new BinaryConverter();
            String firstInputBinary = binaryconverter.FloatToBinary(firstInput.number);
            String secondInputBinary = binaryconverter.FloatToBinary(secondInput.number);
            float value = 0;
            ArrayList intermediateSum = new ArrayList();
            int decimalPointPosition = firstInputBinary.IndexOf('.') + secondInputBinary.IndexOf('.');
            firstInputBinary = firstInputBinary.Replace(".", "");
            secondInputBinary = secondInputBinary.Replace(".", "");
            int BinaryNumber1Length = firstInputBinary.Length;
            int BinaryNumber2Length = secondInputBinary.Length;
            int intermediateSumLength = BinaryNumber1Length + BinaryNumber2Length;
            for (int i = 0; i < intermediateSumLength; i++)
            {
                intermediateSum.Add(0);
            }
            for (int i = 0; i < BinaryNumber2Length; i++)
            {
                int pos = intermediateSumLength - 1 - i;
                for (int j = BinaryNumber1Length - 1; j > -1; j--)
                {
                    if (secondInputBinary[BinaryNumber2Length - 1 - i] == '1' && firstInputBinary[j] == '1')
                    {
                        if (intermediateSum[pos].Equals(1))
                        {
                            for (int k = pos; k > -1; k--)
                            {
                                if (intermediateSum[k].Equals(1))
                                {
                                    intermediateSum[k] = 0;

                                }
                                else
                                {
                                    intermediateSum[k] = 1;
                                    break;

                                }
                            }
                        }
                        else
                        {
                            intermediateSum[pos] = 1;
                        }
                    }
                    pos--;
                }
            }
            value = binaryconverter.BinaryToFloat(intermediateSum, decimalPointPosition);
            FloatNumber result = new FloatNumber(value);
            if ((firstInput.isPositive==false && secondInput.isPositive==true) || (firstInput.isPositive == true && secondInput.isPositive == false) )
            {
               // Console.WriteLine("ok" + "    " + value);
                //value = Math.Abs(value);
               
                result.number = -value;
            }
           // Console.WriteLine("sdf" + result.number);
            return result;


            
        }
    }
}
