using System;

class SubstrCount
{
    static void Main()
    {
        Console.WriteLine("Find the count a substring appears in a given text (case insensitive search)\n");

/*  Sample text: We are living in an yellow submarine. We don't have anything else. 
    Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.   */

        Console.Write("Enter the text: ");
        string text = (Console.ReadLine()).ToLower();
        Console.Write("Enter the substring: ");
        string sbAnyCase = Console.ReadLine();
        string sb = sbAnyCase.ToLower();

        int index = text.IndexOf(sb);
        int cnt=0;
        while (index != -1)
        {
            cnt++;
            index=text.IndexOf(sb,index+1);
        }
        Console.WriteLine("The substring {0} appears in the text {1} times.", sbAnyCase,cnt);
    }
}
