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
            MaterialClassDTO foundMatClassItem = mesMatClassRepo.GetByNId("n/a")?.FirstOrDefault();

            if (foundDMMatItem == null)
            {
                DMMaterialDTOCreateParameter dmMatCrParameter = new DMMaterialDTOCreateParameter(dmMatItem);
                dmMatCrParameter.MaterialId = foundMatItem.Id;
                dmMatCrParameter.LogisticClassNId = "Default";
                dmMatCrParameter.MaterialClassId = foundMatClassItem?.Id;

                mesDMMatRepo.Create(dmMatCrParameter);
            }//if
            else
            {
                foundDMMatItem.UpdateRecord(dmMatItem);
                DMMaterialDTOUpdateParameter dmMatUpParameter = new DMMaterialDTOUpdateParameter(foundDMMatItem);
                dmMatUpParameter.LogisticClassNId = "Default";
                dmMatUpParameter.MaterialClassNId = foundMatClassItem?.NId;
                dmMatUpParameter.Id = foundDMMatItem.Id;
                mesDMMatRepo.Update(dmMatUpParameter);
            }//else

        }//CreateOrUpdateDMMaterial


        /// <summary>
        /// Создание или обновлеие спецификаций к материалам
        /// </summary>
        /// <param name="specEl"></param>
        private void CreateOrUpdateMatSpec(BoMDTO specEl)
        {
            string bomId = null;
            bomId = mesMatRepo.GetBoMByNId(specEl.NId)?.FirstOrDefault()?.Id;
            if (bomId == null)
            {
                BoMDTOCreateParameter dmMatCrParameter = new BoMDTOCreateParameter(specEl);
                var matDefId= mesDMMatRepo.GetByNId(specEl.NId)?.FirstOrDefault();
                dmMatCrParameter.MaterialDefinition = matDefId?.Id;
                dmMatCrParameter.Quantity.UoMNId = matDefId?.Material?.UoMNId;
                bomId = mesMatRepo.CreateBoM(dmMatCrParameter)?.Id;
                foreach(BoMItemDTO item in specEl.Items)
                {
                    BoMItemDTOCreateParameter dmBoMItemCrParameter = new BoMItemDTOCreateParameter(item);
                    matDefId = mesDMMatRepo.GetByNId(item.NId)?.FirstOrDefault();
                    dmBoMItemCrParameter.MaterialDefinition = matDefId?.Id;
                    dmBoMItemCrParameter.Quantity.UoMNId = matDefId?.Material?.UoMNId;
                    dmBoMItemCrParameter.BoM = bomId;
                    dmBoMItemCrParameter.NId = null;
                    mesMatRepo.CreateBoMItem(dmBoMItemCrParameter);
                }//foreach

            }//if
            else
            {
                //Все элементы спецификации по ID BOM 
                List<BoMItemDTO> bomItemAllList= mesMatRepo.GetAllBoMItemByBoMId(bomId);

                foreach (BoMItemDTO item in specEl.Items)
                {
                    var matDefId = mesDMMatRepo.GetByNId(item.NId)?.FirstOrDefault();
                    //Проверяем если в спецификации уже есть деталь обновляем количество, иначе создаем элемент спецификации
                    BoMItemDTO foundBomItem = bomItemAllList?.FirstOrDefault(x => x.MaterialDefinition_Id == matDefId?.Id);
                    if (foundBomItem == null)
                    {
                        BoMItemDTOCreateParameter dmBoMItemCrParameter = new BoMItemDTOCreateParameter(item);
                        matDefId = mesDMMatRepo.GetByNId(item.NId)?.FirstOrDefault();
                        dmBoMItemCrParameter.MaterialDefinition = matDefId?.Id;
                        dmBoMItemCrParameter.Quantity.UoMNId = matDefId?.Material?.UoMNId;
                        dmBoMItemCrParameter.BoM = bomId;
                        dmBoMItemCrParameter.NId = null;
                        mesMatRepo.CreateBoMItem(dmBoMItemCrParameter);
                    }//if
                    else
                    {
                        BoMItemDTODeleteParameter dmBoMItemDelParameter = new BoMItemDTODeleteParameter(foundBomItem);
                        mesMatRepo.DeleteBoMItemList(dmBoMItemDelParameter);
                        BoMItemDTOCreateParameter dmBoMItemCrParameter = new BoMItemDTOCreateParameter(item);
                        matDefId = mesDMMatRepo.GetByNId(item.NId)?.FirstOrDefault();
                        dmBoMItemCrParameter.MaterialDefinition = matDefId?.Id;
                        dmBoMItemCrParameter.Quantity.UoMNId = matDefId?.Material?.UoMNId;
                        dmBoMItemCrParameter.BoM = bomId;
                        dmBoMItemCrParameter.NId = null;
                        mesMatRepo.CreateBoMItem(dmBoMItemCrParameter);

                    }//else
                }//foreach
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
