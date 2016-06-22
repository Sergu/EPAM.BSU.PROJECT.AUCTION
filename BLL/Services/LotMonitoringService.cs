using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BLL.interfaces.Services;
using BLL.interfaces.Entities;
using DAL.Interfaces.Repository;
using BLL.Mappers;
using System.Timers;

namespace BLL.Services
{
    public class LotMonitoringService : ILotMonitoringService
    {
        private ILotService lotService;
        private readonly IUserService userService;
        private readonly Timer timer;
        public LotMonitoringService(  ILotService lotService, IUserService userService)
        {
            this.userService = userService;
            this.lotService = lotService;
            this.timer = new Timer();
            TrackingOverdueActiveLots(null,null);
        }
        private void TrackingOverdueActiveLots(Object source, ElapsedEventArgs e)
        {
            var lots = GetActiveLotsInThePast();
            ChangeLotsState(lots);
            ChangeTimer();
        }
        public void ChangeTimer()
        {
            long elapsedTime;
            var lot = lotService.GetAllActiveLots().OrderBy(l => l.EndDate).FirstOrDefault();
            var remain = lot.EndDate.Subtract(DateTime.Now);
            if (remain.TotalMilliseconds < 86400000)
            {
                elapsedTime = (long)remain.TotalMilliseconds;
            }
            else
                elapsedTime = 86400000;
            timer.Interval = elapsedTime;
            timer.Elapsed += TrackingOverdueActiveLots;
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();
        }

        private IEnumerable<LotEntity> GetActiveLotsInThePast()
        {
            var lots = lotService.GetAllActiveLots().Where(lot => lot.EndDate <= DateTime.Now).Select(lot => lot);
            return lots;
        }
        private void ChangeLotsState(IEnumerable<LotEntity> lots)
        {
            var listLots = lots.ToList();
            foreach(LotEntity lot in listLots){
                ChangeLotState(lot);
            }
        }
        private void ChangeLotState(LotEntity lot)
        {
            lot.IsActive = 0;
            lotService.Update(lot);
            if (!ReferenceEquals(lot.UserBetId,null))
            {
                var bet = lot.CurrentCost.Value;
                var userBetEntity = userService.GetUserById(lot.UserBetId.Value);
                var userSellerEntity = userService.GetUserById(lot.UserSellerId.Value);
                userBetEntity.Money = userBetEntity.Money - bet;
                userSellerEntity.Money = userSellerEntity.Money + bet;
                userService.Update(userBetEntity);
                userService.Update(userSellerEntity);
            }
        }
    }
}
