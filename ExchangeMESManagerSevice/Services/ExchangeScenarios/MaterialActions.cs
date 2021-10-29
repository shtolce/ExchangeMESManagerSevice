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
        //Создание базового справочника материалов
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

        }//CreateOrUpdateMaterial
        //Создание cправочника материалов расширеного на дискретное производство
        private void CreateOrUpdateDMMaterial(DMMaterialDTO dmMatItem)
        {
            DMMaterialDTO foundDMMatItem = null;
            foundDMMatItem = mesDMMatRepo.GetByNId(dmMatItem.Material.NId)?.FirstOrDefault();
            MaterialDTO foundMatItem = mesMatRepo.GetByNId(dmMatItem.Material.NId)?.FirstOrDefault();
            if (foundMatItem == null)
                return;
            MaterialClassDTO foundMatClassItem = mesMatClassRepo.GetByNId("n/a").FirstOrDefault();

            if (foundDMMatItem == null)
            {
                DMMaterialDTOCreateParameter dmMatCrParameter = new DMMaterialDTOCreateParameter(dmMatItem);
                dmMatCrParameter.MaterialId = foundMatItem.Id;
                dmMatCrParameter.LogisticClassNId = "Default";
                dmMatCrParameter.MaterialClassId = foundMatClassItem.Id;

                mesDMMatRepo.Create(dmMatCrParameter);
            }//if
            else
            {
                foundDMMatItem.UpdateRecord(dmMatItem);
                DMMaterialDTOUpdateParameter dmMatUpParameter = new DMMaterialDTOUpdateParameter(foundDMMatItem);
                dmMatUpParameter.LogisticClassNId = "Default";
                dmMatUpParameter.MaterialClassNId = foundMatClassItem.NId;
                dmMatUpParameter.Id = foundDMMatItem.Id;
                mesDMMatRepo.Update(dmMatUpParameter);
            }//else

        }//CreateOrUpdateDMMaterial

        private void CreateOrUpdateMatSpec(BoMDTO specEl)
        {
            List<BoMDTO> foundMatSpecItem = null;
            foundMatSpecItem = mesMatRepo.GetBoMByMatDefNId(specEl.NId);
            if (foundMatSpecItem == null)
            {
                BoMDTOCreateParameter dmMatCrParameter = new BoMDTOCreateParameter(specEl);
                mesMatRepo.CreateBoM(dmMatCrParameter);
            }//if
            else
            {
                /*
                foundMatSpecItem.UpdateRecord(dmMatItem);
                DMMaterialDTOUpdateParameter dmMatUpParameter = new DMMaterialDTOUpdateParameter(foundDMMatItem);
                dmMatUpParameter.LogisticClassNId = "Default";
                dmMatUpParameter.MaterialClassNId = foundMatSpecItem.NId;
                dmMatUpParameter.Id = foundMatSpecItem.Id;
                mesDMMatRepo.Update(dmMatUpParameter);
                */
            }//else




        }

        /// <summary>
        /// Скрипт загрузки материалов спецификаций из скл в MES
        /// </summary>
        private void ImportBomToMes()
        {
            IEnumerable<BoMDTO> matSpecSqlCollection = sqlMatSpecRepo.GetAllBoM().ToList();
            //Создаем или обновляем справочник материалов спецификаций
            foreach (BoMDTO matSpecItem in matSpecSqlCollection)
            {
                CreateOrUpdateMatSpec(matSpecItem);
            }//foreach
        }//ImportMaterialToMes


        /// <summary>
        /// Скрипт загрузки материалов из скл в MES
        /// </summary>
        private void ImportMaterialToMes()
        {
            IEnumerable<MaterialDTO> matSqlCollection = sqlMatRepo.GetAll();
            IEnumerable<DMMaterialDTO> dmMatSqlCollection = sqlDMMatRepo.GetAll();
            //Создаем или обновляем справочник материалов
            foreach (MaterialDTO matItem in matSqlCollection)
            {
                CreateOrUpdateMaterial(matItem);
            }//foreach
            
            //Создаем или обновляем дискретный справочник материалов
            foreach (DMMaterialDTO dmMatItem in dmMatSqlCollection)
            {
                CreateOrUpdateDMMaterial(dmMatItem);
            }//foreach

        }//ImportMaterialToMes


    }
}
