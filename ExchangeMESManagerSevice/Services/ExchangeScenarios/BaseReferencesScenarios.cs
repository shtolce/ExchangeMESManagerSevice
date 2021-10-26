using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.Services.ExchangeScenarios
{
    public class BaseReferencesScenarios
    {
        private MESUoWService _MESUoWService;
        private SQLUoWService _SQLUoWService;

        public BaseReferencesScenarios(MESUoWService MESUoWService, SQLUoWService SQLUoWService)
        {
            _MESUoWService = MESUoWService;
            _SQLUoWService = SQLUoWService;
        }

        private void GetEquipment()
        {
            var test = _SQLUoWService.EquipmentSpecificationSQLRepository.GetAll();


        }

        /// <summary>
        /// Базовые справочники
        /// </summary>
        public void GetScenario1()
        {
            GetEquipment();
        }

    }
}
