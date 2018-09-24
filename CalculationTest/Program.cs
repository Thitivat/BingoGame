using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace CalculationTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string math = "(22*2) + 50";
            Console.WriteLine($"{math} = " + Calculate(math));

            math = "((2*3+12) / 2)";
            Console.WriteLine($"{math} = " + Calculate(math));

            math = "(10-5+3/2*2)";
            Console.WriteLine($"{math} = " + Calculate(math));

            Console.ReadKey();
        }

        public static double Calculate(string expression)
        {
            var xsltExpression =
                $"number({new Regex(@"([\+\-\*])").Replace(expression, " ${1} ").Replace("/", " div ").Replace("%", " mod ")})";

            return (double)new XPathDocument(new StringReader("<r/>")).CreateNavigator().Evaluate(xsltExpression);
        }
    }
}
