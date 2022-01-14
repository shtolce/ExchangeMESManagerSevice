using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        DM_MateriaSQLRepository sqlDMMatRepo;
        MaterialSpecificationSQLRepository sqlMatSpecRepo;
        EquipmentSpecificationSQLRepository sqlEqSpecRepo;
        EquipmentSQLRepository sqlEqRepo;
        EquipmentConfigurationSQLRepository sqlEqConfRepo;
        OperationSQLRepository sqlOpRepo;
        ProcessesSQLRepository sqlProcRepo;
        WOSQLRepository sqlWORepo;
                HttpEquipmentRepository mesEqRepo;
        HttpEquipmentConfigurationRepository mesEqConfRepo;
        HttpMaterialsRepository mesMatRepo;
        HttpDMMaterialsRepository mesDMMatRepo;
        HttpMaterialClassRepository mesMatClassRepo;
        HttpWorkOrdersRepository mesWORepo;
        HttpAsPlannedBOPRepository mes_AsPLannedBOPRepo;

        public BaseReferencesScenarios(MESUoWService MESUoWService, SQLUoWService SQLUoWService)
        {
            _MESUoWService = MESUoWService;
            _SQLUoWService = SQLUoWService;
            //Инициализация репозиториев на стороне ПБД SQL
            sqlEqRepo = _SQLUoWService.EquipmentSQLRepository;
            sqlEqConfRepo = _SQLUoWService.EquipmentConfigurationSQLRepository;
            sqlMatRepo = _SQLUoWService.MateriaSQLRepository;
            sqlMatSpecRepo = _SQLUoWService.MaterialSpecificationSQLRepository;
            sqlDMMatRepo = _SQLUoWService.DM_MateriaSQLRepository;
            sqlOpRepo = _SQLUoWService.OperationSQLRepository;
            sqlProcRepo = _SQLUoWService.ProcessesSQLRepository;
            sqlWORepo = _SQLUoWService.WOSQLRepository;
            sqlEqSpecRepo = _SQLUoWService.EquipmentSpecificationSQLRepository;
            //Инициализация репозиториев на стороне MES
            mesEqRepo = _MESUoWService.EquipmentRepository;
            mesEqConfRepo = _MESUoWService.EquipmentConfigurationRepository;
            mesMatRepo = _MESUoWService.MaterialsRepository;
            mesMatClassRepo = _MESUoWService.MaterialClassRepository;
            mesDMMatRepo = _MESUoWService.DMMaterialsRepository;
            mesWORepo = _MESUoWService.WorkOrdersRepository;
            mes_AsPLannedBOPRepo = _MESUoWService.AsPlannedBOPRepository;
        }

        /// <summary>
        /// Базовые справочники
        /// </summary>
        public void GetScenario1()
        {
            ImportEquipmentToMes();
            ImportMaterialToMes();
            ImportBomToMes();
            ImportOperationToMes();
        }
        /// <summary>
        /// Закачка RunTime
        /// </summary>
        public void GetScenario2()
        {
            ImportOperationToMes();
            ImportWorkOrdersToMes();
        }

    }
}
