using System;
using System.Collections.Generic;
using System.IO;

namespace Bunnies
{
    public class BunniesDataBase
    {    
        internal static void UpdateBunniesDataBase(List<Bunny> bunnies)
        {
            try
            {
                var fileStream = File.Create(BunniesStartUp.BunniesFilePath);

                fileStream.Close();

                using (var streamWriter = new StreamWriter(BunniesStartUp.BunniesFilePath))
                {
                    foreach (var bunny in bunnies)
                    {
                        streamWriter.WriteLine(bunny.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("When writing to Bunnies Database an exception occurred.\n{0}", ex.Message);
            } 
        }
    }
}
