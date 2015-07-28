using System;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
    | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]

public class VersionAttribute : System.Attribute
{
    public int MajorNumber { get; private set; }
    public int MinorNumber { get; private set; }

    public VersionAttribute(int majorNumber, int minorNumber)
    {
        this.MajorNumber = majorNumber;
        this.MinorNumber = minorNumber;
    }
}

[VersionAttribute(2, 16)]

class VersionTest
{
    static void Main()
    {
        Type type = typeof(VersionTest);
        object[] versions = type.GetCustomAttributes(false);
        foreach (VersionAttribute version in versions)
        {
            Console.WriteLine("The class VersionTest has version {0}.{1}",
                version.MajorNumber, version.MinorNumber);
        }
        Console.WriteLine();
    }
}
