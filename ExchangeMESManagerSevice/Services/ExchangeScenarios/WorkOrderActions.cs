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
            string woId = foundWoItem?.Id;
            //Проверяем есть ли созданый WO,для привязки к WO
            if (foundWoItem == null)
            {
                WorkOrderDTOCreateParameter woCrParameter = new WorkOrderDTOCreateParameter(woItem);
                woCrParameter.FinalMaterialId = mat?.Id;
                woCrParameter.Plant = "Завод";
                woId = mesWORepo.CreateWorkOrder(woCrParameter)?.WorkOrderId;
            }//if
            else
            {
                foundWoItem.UpdateRecord(woItem);
                WorkOrderDTOUpdateParameter woUpParameter = new WorkOrderDTOUpdateParameter(foundWoItem);
                woUpParameter.FinalMaterialId = mat?.Id;
                mesWORepo.UpdateWorkOrder(woUpParameter);
            }//else
            //Проверяем есть ли у него созданые операции
            foreach (WorkOrderOperationDTO opEl in woItem.WorkOrderOperations)
            {
                WorkOrderOperationDTO foundWoOp = mesWORepo.GetWorkOrderOperationsByNId(opEl.OperationNId).FirstOrDefault();
                string woOpId = foundWoOp?.Id;
                if (foundWoOp == null )
                {
                    if (opEl == null || opEl?.OperationNId == "")
                        return;
                    WorkOrderOperationDTOCreateParameter woOpCrParameter = new WorkOrderOperationDTOCreateParameter(opEl);
                    //woOpCrParameter.DependencyType = "AfterEnd";
                    woOpCrParameter.WorkOrderId = woId;
                    var test = woOpCrParameter.WorkOrderOperation;
                    woOpId = mesWORepo.CreateWorkOrderOperation(woOpCrParameter)?.Id;
                }
                else
                {
                    foundWoOp.UpdateRecord(opEl);
                    WorkOrderOperationDTOUpdateParameter woOpUpParameter = new WorkOrderOperationDTOUpdateParameter(foundWoOp);
                    //woOpUpParameter.FinalMaterialId = mat?.Id;
                    mesWORepo.UpdateWorkOrderOperation(woOpUpParameter);
                }


                //Теперь нужно проставить связи с пред. операцией
                OperationStructureDependencySQLDTO prevOpRec = sqlWORepo.GetPreviousWOOperationByOrderNo_OpNo(opEl.Sequence, woItem.NId);
                int? prevOpN = prevOpRec?.prevSeq;

                //Есть ли уже созданная зависимость
                WorkOOperationDependencyDTO woOpDepPrev = mesWORepo.GetAllWorkOOperationDependencyByFromWOId(prevOpRec.PrevNId).FirstOrDefault();
                //Мы проверяем только на пред. операцию, что связь существует, если будут паралельные связи, то такую проверку нужно убрать
                if (woOpDepPrev != null)
                    continue;

                
                
                //Создаем зависимые связи между операциями, паралельные или последовательные
                string prevWoOpId = mesWORepo.GetWorkOrderOperationsByNId(prevOpRec.PrevNId)?.FirstOrDefault()?.Id;
                if (prevWoOpId == null)
                    continue;

                WorkOrderOperationDependenciesDTOCreateParameter woOpDepCrParameter = new WorkOrderOperationDependenciesDTOCreateParameter
                {
                    Dependencies = new List<WorkOOperationDependencyParameterDTO>()
                    {
                        new WorkOOperationDependencyParameterDTO
                        {
                            FromId = prevWoOpId,
                            OperationDependencyType = "AfterEnd",
                            ToId =woOpId


                        }
                    }


                };
                mesWORepo.CreateWorkOrderOperationDependencies(woOpDepCrParameter);





            }//foreach





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
