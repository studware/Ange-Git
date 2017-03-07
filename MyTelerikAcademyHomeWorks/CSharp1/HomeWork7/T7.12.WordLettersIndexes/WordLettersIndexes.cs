using System;
    class WordLettersIndexes
{
    static void Main()
    {
        int[] lettCodeNum = new int[53];
        // small letters first
        for (int i = 0; i < 27; i++)
        {
            lettCodeNum[i+1] = 'a' + i;
        }
        // capital letters immediately after
        for (int i = 27, j = 0; i < 53; i++,j++)
        {
            lettCodeNum[i] = 'A' + j;
        }

        string checkWord="";
        Console.WriteLine("Read a word from the console, print the index of its letters in the alphabet.");
        Console.Write("Enter a word: ");
        checkWord = Console.ReadLine();

        for (int i = 0; i < checkWord.Length; i++)
        {
            for (int j = 1; j < 53; j++)
            {
                if (checkWord[i] == lettCodeNum[j])
                {
                    Console.WriteLine("Leter {0} has index: {1}", checkWord[i], j );
                    break;
                }
            }
        }
    }
}
