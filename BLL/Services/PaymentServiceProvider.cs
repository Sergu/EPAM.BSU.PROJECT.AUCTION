using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using DAL.Interfaces.Repository;
using BLL.Mappers;

namespace BLL.Services
{
    public class PaymentServiceProvider : IPaymentServiceProvider
    {
        private readonly IUserService userService;
        public PaymentServiceProvider(IUserService userService)
        {
            this.userService = userService;
        }
        public void PurchaseMoney(UserEntity userEntity,int money)
        {
            userEntity.Money = userEntity.Money + money;
            userService.Update(userEntity);
        }
    }
}
