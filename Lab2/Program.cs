using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {

            //IsBalanced("{ int a = new int[ ] ( ( ) ) }");

            Evaluate("5 3 11 + -");
            string a = "{ int a = new int[ ] ( ( ) ) }";
            IsBalanced(a);
        }



        public static bool IsBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach( char c in s)
            {
                if ( c == '{' || c=='<' || c=='[' || c=='(' )
                {
                    stack.Push(c);
                }
                if (c == '}' || c == '>' || c == ']' || c == ')')
                {
                    try
                    {
                        if (Matches(stack.Peek(), c))
                        {
                            stack.Pop();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private static bool Matches(char open, char close)
        {
            if (open == '{')
                return '}' == close;
            if (open == '<')
                return '>' == close;
            if (open == '(')
                return ')' == close;
            if (open == '[')
                return ']' == close;
            return false;
        }

        // Evaluate("5 3 11 + -")	// returns -9
        // 2.4 3.8 / 2.321 +
        
        public static double? Evaluate(string s)
        {
            // parse into tokens (strings)

            string[] tokens = s.Split();

            Stack<double> stack = new Stack<double>();
            
            foreach(string n in tokens)
            {
                try
                {
                    double number = int.Parse(n);
                    stack.Push(number);
                }
                catch (FormatException)
                {
                    switch (n)
                    {
                        case "+":
                            stack.Push(stack.Pop() + stack.Pop());
                            continue;
                        case "-":
                            stack.Push(-(stack.Pop()) + stack.Pop());
                            continue;
                        case "/":
                            stack.Push((1 / stack.Pop()) * stack.Pop());
                            continue;
                        case "*":
                            stack.Push(stack.Pop() * stack.Pop());
                            continue;
                        default:
                            continue;
                    }
                    
                }

            }

            if ( stack.Count != 1)
            {
                return null;
            }

            return stack.Pop();
        }



    }
}
