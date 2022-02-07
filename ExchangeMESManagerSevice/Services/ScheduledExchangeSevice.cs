using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Services.ExchangeScenarios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Services
{
    public class ScheduledExchangeService : BackgroundService
    {
        private Timer _timer;
        private MESUoWService _MESUoWService;
        private SQLUoWService _SQLUoWService;
        private BaseReferencesScenarios _scenarios;
        public ScheduledExchangeService(MESUoWService mESUoWService, SQLUoWService sQLUoWService)
        {
            _MESUoWService = mESUoWService;
            _SQLUoWService = sQLUoWService;
            _scenarios = new BaseReferencesScenarios(_MESUoWService, _SQLUoWService);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _timer = new Timer(GetNewData, null, TimeSpan.Zero,
                            TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }
        /// <summary>
        /// Общая функция запуска сценариев
        /// </summary>
        /// <param name="state"></param>
        private void GetNewData(object state)
        {
            if (AuthStateHelper.AuthState == false)
                return;
            
            //Базовые справочники
            //_scenarios.GetScenario1();
            //Runtime ордера
            _scenarios.GetScenario2();



        }



    }
}
