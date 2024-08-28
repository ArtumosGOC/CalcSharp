using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcSharp
{
    public class Operations
    {
        private static double memory = 0;

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }
        public static double Mod(double a, double b)
        {
            return a % b;
        }
        public static double Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }
        public static double Sqrt(double a)
        {
            return Math.Sqrt(a);
        }
        public static double Abs(double a)
        {
            return Math.Abs(a);
        }
        public static double Log(double a)
        {
            return Math.Log(a);
        }
        public static double Log10(double a)
        {
            return Math.Log10(a);
        }
        public static double Exp(double a)
        {
            return Math.Exp(a);
        }
        public static double Sin(double a)
        {
            return Math.Sin(a);
        }
        public static double Cos(double a)
        {
            return Math.Cos(a);
        }
        public static double Tan(double a)
        {
            return Math.Tan(a);
        }
        public static double Asin(double a)
        {
            return Math.Asin(a);
        }
        public static double Acos(double a)
        {
            return Math.Acos(a);
        }
        public static double Atan(double a)
        {
            return Math.Atan(a);
        }
        public static void MemorySubtract(double value)
        {
            memory -= value;
        }

        public static double MemoryRecall()
        {
            return memory;
        }

        public static void MemoryClear()
        {
            memory = 0;
        }
    }
}