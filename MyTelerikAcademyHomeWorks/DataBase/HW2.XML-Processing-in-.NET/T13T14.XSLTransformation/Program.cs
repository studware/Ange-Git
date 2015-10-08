namespace T13T14.XSLTransformation
{
    using System;
    using System.Xml.Xsl;
    class Program
    {
        static void Main()
        {
            XslCompiledTransform xslt = 
              new XslCompiledTransform();

            xslt.Load("../../catalogue.xsl");
            xslt.Transform("../../../catalogue.xml", "../../catalogue.html");

            Console.WriteLine("Please find the result files in this project's folder.");
        }
    }
}
