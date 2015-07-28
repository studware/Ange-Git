//  Task 1
//  Implement an extension method Substring(int index, int length) 
//  for the class StringBuilder that returns new StringBuilder 
//  and has the same functionality as Substring in the class String.
  
namespace T1and2.Extensions
{
using System;
using System.Text;
    public static class StringBuilderSubstring
    {
        public static StringBuilder Substring(this StringBuilder someText, int index, int length)
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append(someText.ToString(index, length));            
        }
    }
}
