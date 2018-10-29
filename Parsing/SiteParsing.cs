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
        private static List<string> names = new List<string>();
        private static List<string> discount = new List<string>();
        private static List<int> pages = new List<int>();
        //private static List<string> pagesOnSite = new List<string>();
        private int? maxPage;

        public int? MaxPage { get => maxPage; set => maxPage = value; }
        public static List<string> Names { get => names; set => names = value; }
        public static List<string> Discount { get => discount; set => discount = value; }
        public static List<int> Pages { get => pages; set => pages = value; }
        //public static List<string> PagesOnSite { get => pagesOnSite; set => pagesOnSite = value; }

        public void MainMethod()
        {

            
            var webGet = new HtmlWeb();
            MaxPage = MaxPageOnSite(webGet);

            //for (int i = 1; i < MaxPage; i++)
            //{

                //var url = $"https://letyshops.com/shops?page={i}";

                if (webGet.Load($"https://letyshops.com/shops?page=1") is HtmlDocument document)
                {
                    var nodes = document.DocumentNode.CssSelect("div.b-teaser-list");

                    foreach (var item in nodes)
                    {
                        foreach (var item2 in item.CssSelect("div.b-teaser__title"))
                        {
                            Names.Add(item2.InnerText.CleanInnerText());
                        }
                    }
                    foreach(var item in nodes)
                    { 
                        foreach (var item2 in item.CssSelect("span.b-shop-teaser__cash"))
                        {
                            Discount.Add(item2.InnerText.CleanInnerText());
                        }
                    }

                    Console.WriteLine($"{Names.Count} : {Discount.Count}");

                    for (int j = 0; j <= Names.Count; j++)
                    {
                        Console.WriteLine($"{Names[j]} : {Discount[j]}");
                    }
                } 
            //}
        }

        private static int? MaxPageOnSite(HtmlWeb webGet)
        {
            var url = "https://letyshops.com/shops?page=1";

            if (webGet.Load(url) is HtmlDocument document)
            {
                var maxPage = document.DocumentNode.CssSelect("ul.b-pagination").CssSelect("li.b-pagination__item").CssSelect("a.b-pagination__link");

                foreach (var item in maxPage)
                {
                    if (Int32.TryParse(item.InnerText, out int result))
                    {
                        Pages.Add(result);
                    }
                }

                return Pages.Max();

            }

            return null;
        }
    }
}
   
