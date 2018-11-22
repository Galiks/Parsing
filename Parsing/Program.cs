using BLL;
using Ninject;
using System;

namespace Parsing
{
    class Program
    {
        private static ILetyShopsLogic letyShopsLogic;

        public static ILetyShopsLogic LetyShopsLogic { get => letyShopsLogic; set => letyShopsLogic = value; }

        static void Main(string[] args)
        {
            //NinjectCommon.Registration();

            //LetyShopsLogic = NinjectCommon.Kernel.Get<ILetyShopsLogic>();

            //letyShopsLogic.AddShop("LetyShops");

            //SiteParsing siteParsing = new SiteParsing();

            //siteParsing.MainMethod();

            Console.WriteLine("The end");

            Console.Read();
        }
    }
}
