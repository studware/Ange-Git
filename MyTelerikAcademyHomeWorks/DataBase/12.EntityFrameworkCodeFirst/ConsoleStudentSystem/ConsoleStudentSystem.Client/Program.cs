using System.Data.Entity;
using ConsoleStudentSystem.Models;
using ConsoleStudentSystem.Data;
using ConsoleStudentSystem.Data.Migrations;

public class Startup
{
    private const int StudentsCount = 10;
    private const int HomeworksCount = 25;
    private const int CoursesCount = 15;

    public static void Main()
    {
        CreateNewDatabase();

        SeedDatabase();
    }

    private static void CreateNewDatabase()
    {
        var db = new StudentSystemContext();
        db.Database.Delete();
        db.Database.Create();
    }

    private static void SeedDatabase()
    {
        var rand = new ConsoleStudentSystem.Client.RandomGenerator();
        var seeder = new ConsoleStudentSystem.Client.StudentSystemSeeder(rand);

        seeder.SeedStudents(StudentsCount);
        seeder.SeedCourses(CoursesCount);
        seeder.SeedHomeworks(HomeworksCount);

        seeder.SeedStudentCourses();
        seeder.SeedStudentHomeworks();
    }
}