using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P1.MessagesInBottle
{
    class CipherElement
    {
        public char Letter { get; set; }
        public string Code { get; set; }

        public CipherElement(char letter, string code)
        {
            this.Letter = letter;
            this.Code = code;
        }
    }
}
