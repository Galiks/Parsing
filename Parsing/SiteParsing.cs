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
        HtmlWeb webGet;

        public int? MaxPage { get => maxPage; set => maxPage = value; }
        public static List<string> Names { get => names; set => names = value; }
        public static List<string> Discount { get => discount; set => discount = value; }
        public static List<int> Pages { get => pages; set => pages = value; }
        public HtmlWeb WebGet { get => webGet; set => webGet = value; }

        //public static List<string> PagesOnSite { get => pagesOnSite; set => pagesOnSite = value; }

        public SiteParsing()
        {
            WebGet = new HtmlWeb();
        }

        public void MainMethod()
        {
            MaxPage = MaxPageOnSite(webGet);

            //for (int i = 1; i < MaxPage; i++)
            //{

            //var url = $"https://letyshops.com/shops?page={i}";

            if (WebGet.Load($"https://letyshops.com/shops?page=2") is HtmlDocument document)
            {
                var nodes = document.DocumentNode.CssSelect("div.b-teaser-list");

                //ListOfNames(nodes);

                ListOfDiscount(nodes);


                //for (int i = 0; i < Names.Count; i++)
                //{
                //    Console.WriteLine($"{Names[i]} : {Discount[i]} %");
                //}
                
            }
            //}
        }

        private static void ListOfDiscount(IEnumerable<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {
                // /html/body/div//*/div[@class='b-shop-teaser__cash-value-row']//span[@class='b-shop-teaser__cash']|//span[@class='b-shop-teaser__new-cash']
                foreach (var cashValues in node.SelectNodes("/html/body/div//*/div[@class='b-shop-teaser__cash-value-row']"))
                {
                    Console.WriteLine(cashValues.InnerText.CleanInnerText());                   
                }
            }
        }

        private static void ListOfNames(IEnumerable<HtmlNode> nodes)
        {
            foreach (var item in nodes)
            {
                foreach (var item2 in item.CssSelect("div.b-teaser__title"))
                {
                    Names.Add(item2.InnerText.CleanInnerText());
                }
            }
        }

        /// <summary>
        /// Метод для подсчёта страниц на сайте
        /// </summary>
        /// <param name="WebGet">Переменная для подключения</param>
        /// <returns></returns>
        private static int? MaxPageOnSite(HtmlWeb WebGet)
        {
            var url = "https://letyshops.com/shops?page=1";

            if (WebGet.Load(url) is HtmlDocument document)
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

        //private string ReturnCash(string cash)
        //{
        //    if (!String.IsNullOrEmpty(cash))
        //    {
        //        return cash;
        //    }
        //    else
        //    {
        //        if (WebGet.Load($"https://letyshops.com/shops?page=1") is HtmlDocument document)
        //        {
        //            var nodes = document.DocumentNode.CssSelect("div.b-teaser-list");

        //            foreach (var item in nodes)
        //            {
        //                foreach (var item2 in item.CssSelect("span.b-shop-teaser__new-cash"))
        //                {
        //                    Discount.Add(ReturnCash(item2.InnerText.CleanInnerText()));
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
   
