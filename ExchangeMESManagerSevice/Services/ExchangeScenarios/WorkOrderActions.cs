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


        /// <summary>
        /// Скрипт загрузки ордеров и операций из скл в MES
        /// </summary>
        private void ImportWorkOrdersToMes()
        {
            IEnumerable<WorkOrderDTO> woSqlCollection = sqlWORepo.GetAll();
            var test = sqlWORepo.GetByNId("000000044_16");

            //Создаем или обновляем справочник процессов
            foreach (WorkOrderDTO woItem in woSqlCollection)
            {
            }//foreach



        }//ImportWorkOrdersToMes


    }
}
