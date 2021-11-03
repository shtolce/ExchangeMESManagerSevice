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

        private void CreateOrUpdateWO(WorkOrderDTO woItem)
        {
            AsPlannedBOPDTO foundBoPItem = null;
            WorkOrderDTO foundWoItem = null;
            foundWoItem = mesWORepo.GetByNId(woItem.NId)?.FirstOrDefault();
            foundBoPItem = mes_AsPLannedBOPRepo.GetByNId(woItem.PBOPIdentID)?.FirstOrDefault();
            DMMaterialDTO mat = mesDMMatRepo.GetByNId(woItem.FinalMaterial.Material_NId)?.FirstOrDefault();
            //Проверяем есть ли созданый BoP,для привязки к процессу
            if (foundWoItem == null)
            {
                WorkOrderDTOCreateParameter woCrParameter = new WorkOrderDTOCreateParameter(woItem);
                woCrParameter.FinalMaterialId = mat?.Id;
                woCrParameter.Plant = "Завод";
                string woId = mesWORepo.CreateWorkOrder(woCrParameter)?.WorkOrderId;
            }//if
            else
            {
                foundWoItem.UpdateRecord(woItem);
                WorkOrderDTOUpdateParameter woUpParameter = new WorkOrderDTOUpdateParameter(foundWoItem);
                woUpParameter.FinalMaterialId = mat?.Id;
                mesWORepo.UpdateWorkOrder(woUpParameter);

            }//else

        }//CreateOrUpdateProcess


        /// <summary>
        /// Скрипт загрузки ордеров и операций из скл в MES
        /// </summary>
        private void ImportWorkOrdersToMes()
        {
            IEnumerable<WorkOrderDTO> woSqlCollection = sqlWORepo.GetAll();
            //Создаем или обновляем справочник процессов
            foreach (WorkOrderDTO woItem in woSqlCollection)
            {
                CreateOrUpdateWO(woItem);

            }//foreach

        }//ImportWorkOrdersToMes


    }
}
