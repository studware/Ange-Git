using System;
namespace RefactoringIf
{
    public class VisitCellRefactored
    {
        public void RefactorIfStatements()
        {
            const int MinX = default(int);
            const int MaxX = default(int);
            const int MinY = default(int);
            const int MaxY = default(int);

            int x = default(int);
            int y = default(int);

            bool isInRangeX = x >= MinX && x <= MaxX;
            bool isInRangeY = y >= MinY && y <= MaxY;

            bool shouldVisitCell = default(bool);

            if (isInRangeX && isInRangeY && shouldVisitCell)
            {
                this.VisitCell();
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}