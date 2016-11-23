using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T12.AutoResizable
{
    class AutoResizable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement the ADT stack as auto-resizable array.");
            Console.WriteLine("Resize the capacity on demand\n");

            OurStack<int> stack = new OurStack<int>();
            stack.Push(12);
            stack.Push(34);
            stack.Push(9);

            int[] stackToArray = stack.ToArray();
            Console.WriteLine("Stack contents: ");
            for (int i = 0; i < stackToArray.Length; i++)
            {
                Console.Write("{0} ", stackToArray[i]);
            }
            Console.WriteLine("\nAfter Peek(): {0}\n", stack.Peek());
            Console.WriteLine("After Pop(): {0}\n", stack.Pop());
            Console.WriteLine("Again Peek(): {0}\n", stack.Peek());
            Console.WriteLine("\nThe stack contains 20? {0}\n", stack.Contains(20));
            stack.Clear();
            Console.WriteLine("Count of the stack after Clear(): {0}\n", stack.Count);
        }
    }
}
