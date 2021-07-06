using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Services
{
    public class ScheduledExchangeService : BackgroundService
    {
        private Timer _timer;
        private MESUoWService _MESUoWService;
        private SQLUoWService _SQLUoWService;

        public ScheduledExchangeService(MESUoWService mESUoWService, SQLUoWService sQLUoWService)
        {
            _MESUoWService = mESUoWService;
            _SQLUoWService = sQLUoWService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(getNewData, null, TimeSpan.Zero,
                        TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        private void getNewData(object state)
        {
            var test = _SQLUoWService.EquipmentSpecificationSQLRepository.GetAll();
            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list, list[0]);




        }



    }
}
