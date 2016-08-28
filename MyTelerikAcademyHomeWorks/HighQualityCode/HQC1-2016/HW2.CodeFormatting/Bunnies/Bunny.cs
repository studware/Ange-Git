using System;
using System.Text;
using Bunnies.Contracts;
using Bunnies.Enums;

namespace Bunnies
{
    [Serializable]
    public class Bunny : IBunny
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine(string.Format("{0} - \"I am {1} years old!\"", this.Name, this.Age));
            string fur = this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter();
            writer.WriteLine(string.Format("{0} - \"And I am {1}\"", this.Name, fur));
        }

        public override string ToString()
        {
            const int BuilderSize = 200;

            StringBuilder builder = new StringBuilder(BuilderSize);
            builder.AppendLine(string.Format("Bunny name: {0}", this.Name));
            builder.AppendLine(string.Format("Bunny age: {0}", this.Age));
            string fur = this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter();
            builder.AppendLine(string.Format("Bunny fur: {0}", fur));

            return builder.ToString();
        }
    }
}
