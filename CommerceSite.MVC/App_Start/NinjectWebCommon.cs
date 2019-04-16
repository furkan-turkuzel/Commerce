[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CommerceSite.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CommerceSite.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CommerceSite.MVC.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using CommerceSite.BLL.Abstract;
    using CommerceSite.BLL.Concrete;
    using CommerceSite.DAL.Abstract;
    using CommerceSite.DAL.Concrete.DBContext;
    using CommerceSite.DAL.Concrete.Management;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
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

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICategoriesBLL>().To<CategoriesService>();
            kernel.Bind<IAboutBLL>().To<AboutService>();
            kernel.Bind<IBasketBLL>().To<BasketService>();
            kernel.Bind<IBLogBLL>().To<BlogService>();
            kernel.Bind<ICommentsBLL>().To<CommentsService>();
            kernel.Bind<IContactBLL>().To<ContactService>();
            kernel.Bind<ICustomersBLL>().To<CustomersService>();
            kernel.Bind<IDiscountBLL>().To<DiscountService>();
            kernel.Bind<IFavoriteBLL>().To<FavoriteService>();
            kernel.Bind<IOrderDetailsBLL>().To<OrderDetailsService>();
            kernel.Bind<IOrdersBLL>().To<OrdersService>();
            kernel.Bind<IProductsBLL>().To<ProductsService>();
            kernel.Bind<IScoreBLL>().To<ScoreService>();
            kernel.Bind<ISliderBLL>().To<SliderService>();


            kernel.Bind<ICategoriesDAL>().To<EFCategoriesDAL>();
            kernel.Bind<IAboutDAL>().To<EFAboutDAL>();
            kernel.Bind<IBlogDAL>().To<EFBlogDAL>();
            kernel.Bind<ICommentsDAL>().To<EFCommentsDAL>();
            kernel.Bind<IContactDAL>().To<EFContactDAL>();
            kernel.Bind<ICustomersDAL>().To<EFCustomersDAL>();
            kernel.Bind<IDiscountDAL>().To<EFDiscountDAL>();
            kernel.Bind<IFavoriteDAL>().To<EFFavoriteDAL>();
            kernel.Bind<IOrderDetailsDAL>().To<EFOrderDetailsDAL>();
            kernel.Bind<IOrdersDAL>().To<EFOrdersDAL>();
            kernel.Bind<IProductsDAL>().To<EFProductsDAL>();
            kernel.Bind<IScoreDAL>().To<EFScoreDAL>();
            kernel.Bind<ISliderDAL>().To<EFSliderDAL>();

            kernel.Bind<DbContext>().To<CommerceDBContext>();
        }        
    }
}
