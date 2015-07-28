//  Task 4
//  Create a static class PathStorage with static methods to save and load paths from a text file.
//  Use a file format of your choice.

namespace T1to4Geometry
{
using System;
using System.IO;
using System.Linq;
    public static class PathStorage
    {
        public static void SavePath(Path path, string backupFile, bool appendToFile = false)
        {
            using (StreamWriter fileSaver = new StreamWriter(backupFile, appendToFile))
            {
                for (int i = 0; i < path.PathOfPoints.Count; i++)
                {
                    fileSaver.WriteLine(path.PathOfPoints[i].ToString());
                }
            }
        }

        public static Path LoadPath(string fileName)
        {
            Path loadedPath = new Path();
            using (StreamReader fileReader = new StreamReader(fileName))
            {
                string line = fileReader.ReadLine();

                while (line != null)
                {
                    line = line.Trim('{', '}');
                    double[] pointCoords = line.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                            .Select(d => double.Parse(d)).ToArray();
                    loadedPath.AddPoint(new Point3D(pointCoords[0], pointCoords[1], pointCoords[2]));
                    line = fileReader.ReadLine();
                }
            }
            return loadedPath;
        }
    }
}
