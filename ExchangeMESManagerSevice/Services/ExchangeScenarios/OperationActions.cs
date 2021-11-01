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
            ProcessesDTO foundProcItem = null;
            foundProcItem = mes_AsPLannedBOPRepo.GetAllProcessByNId(procItem.NId)?.FirstOrDefault();
            if (foundProcItem == null)
            {
                ProcessesDTOCreateParameter procCrParameter = new ProcessesDTOCreateParameter(procItem);
                mes_AsPLannedBOPRepo.CreateProcess(procCrParameter);
            }//if
            else
            {
//                foundProcItem.UpdateRecord(procItem);
                //OperationDTOUpdateParameter opUpParameter = new OperationDTOUpdateParameter(foundProcItem);
                //mes_AsPLannedBOPRepo.UADMUpdateOperation(opUpParameter);
            }//else

        }//CreateOrUpdateOperation



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
