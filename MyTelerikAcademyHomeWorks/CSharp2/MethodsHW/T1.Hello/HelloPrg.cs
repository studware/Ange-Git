using System;
using System.Text;

namespace T1.Hello
{
    class HelloPrg
    {
    static void Hello()
        {
            Console.Write("Please, enter your name: ");
            Console.WriteLine("Hello, {0}", Console.ReadLine());
        }
       static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Hello();
        }
    }
}
