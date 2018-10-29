using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing
{
    class SiteParsing
    {
        static List<string> names = new List<string>();
        static List<string> discount = new List<string>();
        static List<int> pages = new List<int>();

        public void MainMethod()
        {
            var url = "https://letyshops.com/shops?page=1";
            var webGet = new HtmlWeb();
            if (webGet.Load(url) is HtmlDocument document)
            {
                var maxPage = document.DocumentNode.CssSelect("ul.b-pagination").CssSelect("li.b-pagination__item").CssSelect("a.b-pagination__link");

                foreach (var item in maxPage)
                {
                    if (Int32.TryParse(item.InnerText, out int result))
                    {
                        pages.Add(result);
                    }
                }

                Console.WriteLine(pages.Max());

                var nodes = document.DocumentNode.CssSelect("div.b-teaser-list");

                foreach (var item in nodes)
                {
                    foreach (var item2 in item.CssSelect("div.b-teaser__title"))
                    {
                        names.Add(item2.InnerText.CleanInnerText());
                    }

                    foreach (var item2 in item.CssSelect("span.b-shop-teaser__cash"))
                    {
                        discount.Add(item2.InnerText.CleanInnerText());
                    }
                }

                for (int i = 0; i < discount.Count; i++)
                {
                    Console.WriteLine($"{names[i]} : {discount[i]}");
                }
            }
        }
    }
}
   
