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

        private void CreateOrUpdateProcess(ProcessesDTO procItem)
        {
            AsPlannedBOPDTO foundBoPItem = null;
            ProcessesDTO foundProcItem = null;
            foundProcItem = mes_AsPLannedBOPRepo.GetAllProcessByNId(procItem.NId)?.FirstOrDefault();
            foundBoPItem = mes_AsPLannedBOPRepo.GetByNId(procItem.NId)?.FirstOrDefault();
            DMMaterialDTO mat = mesDMMatRepo.GetByNId(procItem.FinalMaterialNId)?.FirstOrDefault();
            //Проверяем есть ли созданый BoP,для привязки к процессу
            if (foundBoPItem == null)
            {
                AsPlannedBOPDTOCreateParameter boPCrParameter = new AsPlannedBOPDTOCreateParameter(procItem);
                string id = mes_AsPLannedBOPRepo.CreateAsPlannedBOP(boPCrParameter)?.Id;
                foundBoPItem = mes_AsPLannedBOPRepo.GetById(id)?.FirstOrDefault();
            }//if
            if (foundBoPItem == null)
                return;
            if (foundProcItem == null)
            {
                ProcessesDTOCreateParameter procCrParameter = new ProcessesDTOCreateParameter(procItem);
                procCrParameter.AsPlannedBOPId = foundBoPItem.Id;
                procCrParameter.FinalMaterialId = mat?.Id;
                procCrParameter.Plant = "Завод";
                procCrParameter.Quantity = mat.Volume;
                string procId =mes_AsPLannedBOPRepo.CreateProcess(procCrParameter).Id;

                ProcessesDTOLinkToAsPlannedBOP procLinkBoP = new ProcessesDTOLinkToAsPlannedBOP
                {
                    AsPlannedBOPId = foundBoPItem.Id,
                    ProcessId = procId
                };
                mes_AsPLannedBOPRepo.LinkProcessToAsPlannedBOP(procLinkBoP);
            }//if
            else
            {
                foundProcItem.UpdateRecord(procItem);
                ProcessesDTOUpdateParameter procUpParameter = new ProcessesDTOUpdateParameter(foundProcItem);
                procUpParameter.FinalMaterialId = mat?.Id;
                mes_AsPLannedBOPRepo.UpdateProcess(procUpParameter);
                ProcessesDTOLinkToAsPlannedBOP procLinkBoP = new ProcessesDTOLinkToAsPlannedBOP
                {
                    AsPlannedBOPId = foundBoPItem.Id,
                    ProcessId = foundProcItem.Id
                };
                //Мы всегда связываем процесс с БОП , даже если уже связано. Это вызовет возврат ошибки в ответе, не страшно
                mes_AsPLannedBOPRepo.LinkProcessToAsPlannedBOP(procLinkBoP);

            }//else

        }//CreateOrUpdateProcess



        //Создание базового справочника операций. но не базовых опреаций в каталоге, т.к. последние не привязаны к последовательности в прцоессах
        private void CreateOrUpdateOperation(OperationDTO opItem)
        {
            OperationDTO foundOpItem = null;
            foundOpItem = mes_AsPLannedBOPRepo.GetAllOperationsByNId(opItem.NId)?.FirstOrDefault();
            if (foundOpItem == null)
            {
                OperationDTOCreateParameter opCrParameter = new OperationDTOCreateParameter(opItem);
                mes_AsPLannedBOPRepo.UADMCreateOperation(opCrParameter);
            }//if
            else
            {
                foundOpItem.UpdateRecord(opItem);
                OperationDTOUpdateParameter opUpParameter = new OperationDTOUpdateParameter(foundOpItem);
                mes_AsPLannedBOPRepo.UADMUpdateOperation(opUpParameter);
            }//else

        }//CreateOrUpdateOperation


        /// <summary>
        /// Скрипт загрузки Процессов и операций из скл в MES
        /// </summary>
        private void ImportOperationToMes()
        {
            IEnumerable<OperationDTO> opSqlCollection = sqlOpRepo.GetAll();
            IEnumerable<ProcessesDTO> procSqlCollection = sqlProcRepo.GetAll();
            //Создаем или обновляем справочник процессов
            foreach (ProcessesDTO procItem in procSqlCollection)
            {
                CreateOrUpdateProcess(procItem);
            }//foreach



            //Создаем или обновляем справочник операций
            foreach (OperationDTO opItem in opSqlCollection)
            {
                //CreateOrUpdateOperation(opItem);
            }//foreach

        }//ImportOperationToMes


    }
}
