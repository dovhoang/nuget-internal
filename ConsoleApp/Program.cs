using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // var xml = XDocument.Load(@"/Users/doviet-hoang/fcs/project/vfivestore/epos_kiosk_android/Resources/values-w1440dp/dimens.xml");
            // var query = from c in xml.Root.Descendants("dimen")
            //     select (c.Attribute("name"), c.Value);
            //
            // const double descPpi = 1000;
            // const int sourceDpi = 1440;
            // const double ratio = descPpi / sourceDpi;
            // Console.WriteLine("<resources>");
            // foreach (var item in query)
            // {
            //     Console.WriteLine("<dimen {0}>{1}</dimen>", item.Item1, ToNewValue(item.Item2, ratio));
            // }
            // Console.WriteLine("</resources>");
            Console.WriteLine("parameters: ");
            string parameters = Console.ReadLine();
            Console.WriteLine("className: ");
            string className = Console.ReadLine();
            var parms = parameters.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine($"public class {className}\n{{");
            Console.WriteLine($"public {className} ({parameters})\n{{");
            parms.ForEach(x =>
            {
                var parts = x.Trim().Split(" ");
                var upper =  parts[1].First().ToString().ToUpper() + parts[1][1..];
                Console.WriteLine($"{upper} = {parts[1]};" );
            });
            Console.WriteLine("}");
            parms.ForEach(x =>
            {
                var parts = x.Trim().Split(" ");
                parts[1] =  parts[1].First().ToString().ToUpper() + parts[1][1..];
                Console.WriteLine($"public {parts[0]} {parts[1]} {{ get; }}" );
            });
            Console.WriteLine("}");

        }

        private static string ToNewValue(string oldValue, double ratio)
        {
            var value = oldValue.Substring(0, oldValue.Length - 2);
            var unit = oldValue.Substring(oldValue.Length - 2, 2);
            return Math.Round(int.Parse(value) * ratio) + unit;
        }
    }
}
