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
        private void CreateOrUpdateEqiupmentConf(EquipmentConfigurationDTO eqItem)
        {
            EquipmentConfigurationDTO foundEqConfItem = null;
            foundEqConfItem = mesEqConfRepo.GetByNId(eqItem.NId)?.FirstOrDefault();
            if (foundEqConfItem == null)
            {
                EquipmentConfigurationDTOCreateParameter eqConfCrParameter = new EquipmentConfigurationDTOCreateParameter(eqItem);
                mesEqConfRepo.Create(eqConfCrParameter);
            }//if
            else
            {
                foundEqConfItem.UpdateRecord(eqItem);
                EquipmentConfigurationDTOUpdateParameter eqConfUpParameter = new EquipmentConfigurationDTOUpdateParameter(foundEqConfItem);
                mesEqConfRepo.Update(eqConfUpParameter);
            }//else

        }

        private void CreateOrUpdateEqiupment(EquipmentDTO eqItem)
        {
            EquipmentDTO foundEqItem = null;
            foundEqItem = mesEqRepo.GetByNId(eqItem.NId)?.FirstOrDefault();
            if (foundEqItem == null)
            {
                EquipmentDTOCreateParameter eqCrParameter = new EquipmentDTOCreateParameter(eqItem);
                mesEqRepo.Create(eqCrParameter);
            }//if
            else
            {
                foundEqItem.UpdateRecord(eqItem);
                EquipmentDTOUpdateParameter eqUpParameter = new EquipmentDTOUpdateParameter(foundEqItem);
                mesEqRepo.Update(eqUpParameter);
            }//else

        }

        /// <summary>
        /// Скрипт загрузки оборудования из скл в MES
        /// </summary>
        private void ImportEquipmentToMes()
        {
            IEnumerable<EquipmentDTO> equipSqlCollection = sqlEqRepo.GetAll();
            IEnumerable<EquipmentConfigurationDTO> equipmentConfSqlCollection = sqlEqConfRepo.GetAll();
            //Создаем или обновляем конфигурацию оборудования
            foreach (EquipmentConfigurationDTO eqItem in equipmentConfSqlCollection)
            {
                CreateOrUpdateEqiupmentConf(eqItem);
            }//foreach
            //Создаем или обновляем оборудование с шаблоном конфигурации
            foreach (EquipmentDTO eqItem in equipSqlCollection)
            {
                CreateOrUpdateEqiupment(eqItem);
            }//foreach
        }//ImportEquipmentToMes


    }
}
