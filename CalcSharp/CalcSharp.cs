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
        public static double Factorial(double a)
        {
            if (a == 0)
            {
                return 1;
            }
            return a * Factorial(a - 1);
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
        public static void MemoryAdd(double value)
        {
            memory += value;
        }

        public static double MemoryRecall()
        {
            return memory;
        }

        public static void MemoryClear()
        {
            memory = 0;
        }

        public static double EvaluateExpression(string expression)
        {
            Stack<double> values = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsWhiteSpace(expression[i]))
                    continue;

                if (char.IsDigit(expression[i]))
                {
                    StringBuilder sb = new StringBuilder();
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        sb.Append(expression[i++]);
                    }
                    values.Push(double.Parse(sb.ToString()));
                    i--;
                }
                else if (expression[i] == '(')
                {
                    operators.Push(expression[i]);
                }
                else if (expression[i] == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
                    }
                    operators.Pop();
                }
                else if (IsOperator(expression[i]))
                {
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(expression[i]))
                    {
                        values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
                    }
                    operators.Push(expression[i]);
                }
            }

            while (operators.Count > 0)
            {
                values.Push(ApplyOperator(operators.Pop(), values.Pop(), values.Pop()));
            }

            return values.Pop();
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c =='%';
        }

        private static int Precedence(char operador)
        {
            switch (operador)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case '^':
                case '%':
                    return 2;
            }
            return 0;
        }

        private static double ApplyOperator(char operador, double b, double a)
        {
            switch (operador)
            {
                case '+':
                    return Add(a, b);
                case '-':
                    return Subtract(a, b);
                case '*':
                    return Multiply(a, b);
                case '/':
                    return Divide(a, b);
                case '%':
                    return Mod(a, b);
                case '^':
                    return Pow(a, b);
            }
            throw new ArgumentException("Operador inválido");
        }


    }
}