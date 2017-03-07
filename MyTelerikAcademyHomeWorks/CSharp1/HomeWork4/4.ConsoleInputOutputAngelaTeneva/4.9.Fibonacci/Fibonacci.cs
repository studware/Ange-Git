using System;
using System.Numerics;

    class Fibonacci
    {
        static void Main()
        {
            Console.WriteLine("First 100 members of the Fibonacci sequence: 0,1,1,2,3,5,8,13,21,34,55,89,....");
            BigInteger beforePrevious=0;
            BigInteger previousNum=1;
            BigInteger fibonacciNum = 1;
            Console.WriteLine(" 1.\t {0} \n 2.\t {1}", beforePrevious, previousNum);
            for(int i=3; i<101; i++)
            {
                Console.WriteLine(" {0}.\t {1}", i, fibonacciNum);
                beforePrevious = previousNum;
                previousNum = fibonacciNum;
                fibonacciNum = beforePrevious + previousNum;
            }

        }
    }
