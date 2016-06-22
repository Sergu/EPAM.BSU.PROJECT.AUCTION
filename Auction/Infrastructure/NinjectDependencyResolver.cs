using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using DAL.Interfaces.Repository;
using DAL.Concrete;
using BLL.Services;
using BLL.interfaces.Services;
using ORM;

namespace Auction.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        public object GetInstanse<T>()
        {
            return kernel.TryGet<T>();
        }
        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<AuctionDbEntities>().InRequestScope();
            kernel.Bind<ILotMonitoringService>().To<LotMonitoringService>().InSingletonScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ILotService>().To<LotService>();
            kernel.Bind<ILotRepository>().To<LotRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
        }
    }
}