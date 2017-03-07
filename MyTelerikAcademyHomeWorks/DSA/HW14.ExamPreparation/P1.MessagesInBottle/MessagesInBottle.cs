using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.MessagesInBottle
{
    class MessagesInBottle
    {
        static void Main()
        {
            string secretCode = Console.ReadLine();
            string cipher = Console.ReadLine();

            CipherDecoder decoder = new CipherDecoder(secretCode, cipher);

            List<string> originalMessages = decoder.Decode();

            originalMessages.Sort();

            Console.WriteLine(originalMessages.Count);
            foreach (string message in originalMessages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
