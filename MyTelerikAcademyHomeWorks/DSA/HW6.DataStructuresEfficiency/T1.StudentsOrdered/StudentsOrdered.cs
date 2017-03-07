using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T1.StudentsOrdered
{
    public class StudentsOrdered
    {
        public static void Main()
        {
            List<string[]> students = ReadData();
            OrderedMultiDictionary<string, Student> byCourse = new OrderedMultiDictionary<string,Student>(true);
            foreach (var student in students)
            {
                Student st = new Student(student[0], student[1]);
                byCourse.Add(student[2], st);
            }
           
            foreach (var student in byCourse)
            {
                Console.WriteLine(string.Format("{0}: {1}",student.Key, string.Join(", ", student.Value)));
            }
        }

        private static List<string[]> ReadData()
        {
            List<string[]> students = new List<string[]>();
            string sourceFilePath = "../../students.txt";
            string[] lines = File.ReadAllLines(sourceFilePath);
            foreach (var line in lines)
            {
                var student = line.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                students.Add(student);
            }

            return students;
        }

    }
}