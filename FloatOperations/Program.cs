using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatOperations
{
   
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \n1 : Addition \n2 : Multiplication");
            int choice = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter First Number");
            FloatNumber firstInput = new FloatNumber(float.Parse(Console.ReadLine()));
            Console.WriteLine("Enter First Number");
            FloatNumber secondInput = new FloatNumber(float.Parse(Console.ReadLine()));
            float result=0;
            switch (choice)
            {
                case 1:
                    result = (firstInput + secondInput).number;
                    break;
                case 2:
                    result = (firstInput * secondInput).number;
                    break;
            }          
            Console.WriteLine("Result: "+result);
          //  Console.WriteLine(new BinaryConverter().BinaryToFloat(new StringBuilder("101."));
            Console.ReadKey();
        }
    }
}
