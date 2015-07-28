using System;

public class RefactorIfStatements
{
    public static void Main()
    {
        Potato potato = new Potato();

        // ... 
        if (potato != null && potato.HasBeenPeeled && !potato.IsRotten)
        {
            Cook(potato);
        }

        int x = 0;
        int y = 0;
        const int MinX = -200;
        const int MaxX = 200;
        const int MinY = -200;
        const int MaxY = 200;

        bool shouldVisitCell = true;
        bool inRangeX = MinX <= x && x <= MaxX;
        bool inRangeY = MinY <= y && y <= MaxY;

        if (inRangeX && inRangeY && shouldVisitCell)
        {
            VisitCell();
        }
    }

    private static void Cook(Potato potato)
    {
        throw new NotImplementedException();
    }

    private static void VisitCell()
    {
        throw new NotImplementedException();
    }
}