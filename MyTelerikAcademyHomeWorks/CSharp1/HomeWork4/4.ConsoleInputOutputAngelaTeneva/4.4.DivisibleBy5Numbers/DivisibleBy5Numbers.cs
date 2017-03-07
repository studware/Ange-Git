using System;
    class DivisibleBy5Numbers
    {
        static void Main()
        {
            Console.WriteLine("Read two positive integer numbers");
            Console.WriteLine("and print how many numbers p divisible by 5 are between them(inclusive)");
            string inputNumber;
            uint m;
            uint n;
            uint p=0;
            uint tempVar;
            do
                {
                    Console.Write("Enter a positive integer number: ");    
                }
            while(!uint.TryParse(inputNumber=Console.ReadLine(), out m));
            do
                {
                    Console.Write("Enter a second positive integer number: ");    
                }
            while(!uint.TryParse(inputNumber=Console.ReadLine(), out n));
            tempVar=m;
            if (n<m)
                {
                    tempVar=n;
                    n=m;
                    m=tempVar;
                }
            for (int i=0; i<5; i++)
                {
                    if((tempVar<=n)&&(tempVar%5==0))
                    {
                        p++;
                        break;
                    }
                    tempVar++;
                }
            while (tempVar <= n)
            {
                tempVar += 5;
                if (tempVar <= n)
                {
                    p++;
                }
            }
            Console.WriteLine("The are {0} numbers divisible by 5 whithout residue between {1} and {2}", p, m, n);
        }
    }
