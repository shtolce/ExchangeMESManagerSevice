using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.DTOModels;
using ExchangeMESManagerSevice.Services.SQLServices;

namespace ExchangeMESManagerSevice.Services.ExchangeScenarios
{
    public partial class BaseReferencesScenarios
    {
        private MESUoWService _MESUoWService;
        private SQLUoWService _SQLUoWService;
        MaterialSQLRepository sqlMatRepo;
        EquipmentSQLRepository sqlEqRepo;
        EquipmentConfigurationSQLRepository sqlEqConfRepo;
        HttpEquipmentRepository mesEqRepo;
        HttpEquipmentConfigurationRepository mesEqConfRepo;
        HttpMaterialsRepository mesMatRepo;

        public BaseReferencesScenarios(MESUoWService MESUoWService, SQLUoWService SQLUoWService)
        {
            _MESUoWService = MESUoWService;
            _SQLUoWService = SQLUoWService;
            //Инициализация репозиториев на стороне ПБД SQL
            sqlEqRepo = _SQLUoWService.EquipmentSQLRepository;
            sqlEqConfRepo = _SQLUoWService.EquipmentConfigurationSQLRepository;
            sqlMatRepo = _SQLUoWService.MateriaSQLRepository;
            //Инициализация репозиториев на стороне MES
            mesEqRepo = _MESUoWService.EquipmentRepository;
            mesEqConfRepo = _MESUoWService.EquipmentConfigurationRepository;
            mesMatRepo = _MESUoWService.MaterialsRepository;
        }

        /// <summary>
        /// Базовые справочники
        /// </summary>
        public void GetScenario1()
        {
            ImportEquipmentToMes();
            ImportMaterialToMes();
        }

    }
}
