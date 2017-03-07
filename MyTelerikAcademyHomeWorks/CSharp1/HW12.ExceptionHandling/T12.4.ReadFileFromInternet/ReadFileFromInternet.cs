using System;
using System.Net;

class ReadFileFromInternet
{
    static void Main()
    {
        Console.WriteLine("Write a program that downloads a file from Internet\ne.g. http://www.devbg.org/img/Logo-BASD.jpg)\nand stores it into the current directory of the project:\n");
        using (WebClient webFile = new WebClient())
        {
            try
            {
                webFile.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../logoBASD.jpg");
                Console.WriteLine("The file was successfully loaded");
            }
                
            catch (WebException)
            {
                Console.Error.WriteLine("The address is invalid.");
            }

            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
            catch (InvalidOperationException)
            {
                Console.Error.WriteLine("File ../../logoBASD.jpg is open by another program.\nPlease, close it and try again!");
            }
        }
    }
}