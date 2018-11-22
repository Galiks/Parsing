using BLL;
using DAL;
using Ninject;

namespace Ninject
{
    public static class NinjectCommon
    {
        private static readonly IKernel _kernel = new StandardKernel();

        public static IKernel Kernel => _kernel;

        public static void Registration()
        {
            _kernel.Bind<ILetyShopsDAO>().To<LetyShopsDAO>();
            _kernel.Bind<ILetyShopsLogic>().To<LetyShopsLogic>();
        }
    }
}
