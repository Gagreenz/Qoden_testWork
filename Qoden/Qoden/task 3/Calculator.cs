using Qoden.task_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qoden.task_3
{
    class Calculator
    {
        public string Calculate(string postfixExp)
        {
            Stack<string> stack = new Stack<string>();
            var tokens = postfixExp.Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].All(Char.IsDigit))
                {
                    stack.Push(tokens[i]);
                    continue;
                }

                var first = float.Parse(stack.Pop());
                var second = float.Parse(stack.Pop());
                var result = "";

                switch (tokens[i]) 
                {
                    case "+":
                        result = (second + first).ToString();
                        stack.Push(result);
                        break;
                    case "-":
                        result = (second - first).ToString();
                        stack.Push(result);
                        break;
                    case "*":
                        result = (second * first).ToString();
                        stack.Push(result);
                        break;
                    case "/":
                        result = (second / first).ToString();
                        stack.Push(result);
                        break;

                }
            }
            return stack.Pop();
        }
    }
}
