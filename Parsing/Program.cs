using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            SiteParsing siteParsing = new SiteParsing();

            siteParsing.MainMethod();

            Console.WriteLine("The end");

            Console.Read();
        }
    }
}
