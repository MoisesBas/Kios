using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KiosExam.BLL;
using KiosExam.DAL;
using KiosExam.DAL.Interface;

[assembly:PreApplicationStartMethod(typeof(KiosExam.UI.App_Start.NinjectWebCommon), "Start")]
namespace KiosExam.UI.App_Start
{
    

    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();              

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IKiosExamRepo>().To<KiosExamRepo>();
            kernel.Bind<IKiosExam>().To<KiosExamBLL>();
        }
    }
}