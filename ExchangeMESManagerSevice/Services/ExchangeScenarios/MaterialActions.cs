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
        private void CreateOrUpdateMaterial(MaterialDTO matItem)
        {
            MaterialDTO foundMatItem = null;
            foundMatItem = mesMatRepo.GetByNId(matItem.NId)?.FirstOrDefault();
            if (foundMatItem == null)
            {
                MaterialDTOCreateParameter matCrParameter = new MaterialDTOCreateParameter(matItem);
                mesMatRepo.Create(matCrParameter);
            }//if
            else
            {
                foundMatItem.UpdateRecord(matItem);
                MaterialDTOUpdateParameter matUpParameter = new MaterialDTOUpdateParameter(foundMatItem);
                mesMatRepo.Update(matUpParameter);
            }//else

        }

        /// <summary>
        /// Скрипт загрузки материалов из скл в MES
        /// </summary>
        private void ImportMaterialToMes()
        {
            IEnumerable<MaterialDTO> matSqlCollection = sqlMatRepo.GetAll();
            //Создаем или обновляем справочник материалов
            foreach (MaterialDTO matItem in matSqlCollection)
            {
                CreateOrUpdateMaterial(matItem);
            }//foreach
        }//ImportMaterialToMes


    }
}
