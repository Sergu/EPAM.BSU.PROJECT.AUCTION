﻿using System;
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
using System.Web.Security;
using Auction.Providers;

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
        private void AddBindings()
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<WebAuctionEntities>().InRequestScope();
            kernel.Bind<ILotMonitoringService>().To<LotMonitoringService>().InSingletonScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ILotService>().To<LotService>();
            kernel.Bind<ILotRepository>().To<LotRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IPaymentServiceProvider>().To<PaymentServiceProvider>();
            kernel.Bind<IBetHistoryRepository>().To<BetHistoryRepository>();
            kernel.Bind<IBetHistoryService>().To<BetHistoryService>();
            kernel.Bind<IUserInRoleRepository>().To<UserInRoleRepository>();
            kernel.Bind<IUserInRoleService>().To<UserInRoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<RoleProvider>().To<CustomRoleProvider>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<IAlbumRepository>().To<AlbumRepository>();
            kernel.Bind<IPhotoInAlbumRepository>().To<PhotoInAlbumRepository>();
            kernel.Bind<IPhotoService>().To<PhotoService>();
            kernel.Bind<IAlbumService>().To<AlbumService>();
            kernel.Bind<IPhotoInAlbumService>().To<PhotoInAlbumService>();

        }
    }
}