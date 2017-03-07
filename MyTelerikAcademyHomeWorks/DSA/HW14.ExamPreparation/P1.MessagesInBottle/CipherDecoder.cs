using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.MessagesInBottle
{
    /// <summary>
    /// Decodes a secretCode message (using List<CipherElement> cipherElements key) into List<string> originalMessages
    /// </summary>
    class CipherDecoder
    {
        readonly List<CipherElement> cipherElements;
        readonly string secretCode;
        List<string> originalMessages;

        /// <summary>
        /// Forms the cipherElements list of type <CipherElement> from the cipher 
        /// with the letter/ciphers tupples and takes the secret code which is to be decoded 
        /// </summary>
        /// <param name="secretCode">The secret code (message1)</param>
        /// <param name="cipher">The cipher (message2)</param>
        public CipherDecoder(string secretCode, string cipher)
        {
            cipherElements = new List<CipherElement>();

            StringBuilder currentCipher = new StringBuilder();
            char lastChar = '\0';
            foreach (char ch in cipher)
            {
                if (ch >= 'A' && ch <= 'Z') // is it a Latin capital letter?
                {
                    if (currentCipher.Length > 0)
                    {
                        cipherElements.Add(new CipherElement(lastChar, currentCipher.ToString()));
                        currentCipher.Clear();
                    }
                    lastChar = ch;
                }
                else
                {
                    currentCipher.Append(ch);
                }
            }
            if (currentCipher.Length > 0)
            {
                cipherElements.Add(new CipherElement(lastChar, currentCipher.ToString()));
            }

            this.secretCode = secretCode;
        }

        char[] currentOriginalMessage = new char[100];

        /// <summary>
        /// Adds the current original message found to the result list
        /// </summary>
        /// <param name="currentOriginalMessage">Current version of the original message decoded</param>
        private void AddSolution(char[] currentOriginalMessage)
        {
            StringBuilder originalMessage = new StringBuilder();
            foreach (char c in currentOriginalMessage)
            {
                if (c < 'A' || c > 'Z') break;
                originalMessage.Append(c);
            }
            originalMessages.Add(originalMessage.ToString());
        }

        /// <summary>
        /// Decodes the message using recursion
        /// </summary>
        /// <param name="index">current index of the secret code</param>
        /// <param name="wordIndex">current index in the solution list</param>
        private void DecodeWithRecursion(int index, int wordIndex)
        {
            if (index == secretCode.Length)
            {
                AddSolution(currentOriginalMessage);
                return;
            }
            if (index > secretCode.Length) return;
            foreach (var element in cipherElements)
            {
                if (secretCode.Length >= index + element.Code.Length 
                    && secretCode.Substring(index, element.Code.Length) == element.Code)
                {
                    currentOriginalMessage[wordIndex] = element.Letter;
                    DecodeWithRecursion(index + element.Code.Length, wordIndex + 1);
                    currentOriginalMessage[wordIndex] = '\0';
                }
            }
        }

        /// <summary>
        /// Decodes the original messages using DecodeWithRecursion() method and returns the result
        /// </summary>
        /// <returns>result - the original message decoded</returns>
        public List<string> Decode()
        {
            originalMessages = new List<string>();
            DecodeWithRecursion(0, 0);
            return originalMessages;
        }
    }
}
