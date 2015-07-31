namespace T2.Exceptions
{
    using System;
    public class CSharpExam : Exam
    {
        private const int MinGrade = 0;
        private const int MaxGrade = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < CSharpExam.MinGrade || value > CSharpExam.MaxGrade)
                {
                    throw new ArgumentException(String.Format("The score must be within the range [{0}; {1}].", MinGrade, MaxGrade));
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.Score < CSharpExam.MinGrade || this.Score > CSharpExam.MaxGrade)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return new ExamResult(this.Score, MinGrade, MaxGrade, "Exam results calculated by score.");
            }
        }
    }
}
