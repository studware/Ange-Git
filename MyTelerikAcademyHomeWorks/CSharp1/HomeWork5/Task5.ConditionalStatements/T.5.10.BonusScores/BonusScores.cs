using System;

class BonusScores
{
    static void Main()
    {
        int scores;
        int scoresWithBonus=0;
        string scoresName;
        Console.WriteLine("Please enter scores (from 1 to 9): ");
        int.TryParse(scoresName = Console.ReadLine(), out scores);
        switch (scores)
        {
            case 1:
            case 2:
            case 3:
                scoresWithBonus=scores*10;
                break;
            case 4:
            case 5:
            case 6:
                scoresWithBonus=scores*100;
                break;
            case 7:
            case 8:
            case 9:
                scoresWithBonus=scores*1000;
                break;
            default:
                Console.WriteLine("The value you entered is not a digit or is not in the range [1....9].");
                break;
        }
        if (scores < 10 && scores > 0)
        {
            Console.WriteLine("The scores {0} with bonus are: {1}", scores, scoresWithBonus);
        }
    }
}
