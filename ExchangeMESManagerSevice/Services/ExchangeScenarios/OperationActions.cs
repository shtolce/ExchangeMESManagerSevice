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
            ProcessesDTO foundProcItem = null;
            AsPlannedBOPDTO foundBoPItem = null;
            ProcessToOperationLinkDTO fOpItemPrev = null;
            ProcessToOperationLinkDTO fOpItem = null;
            OperationDTO foundOpItem = null;
            OperationStructureDependencySQLDTO prevOpRec = sqlOpRepo.GetPreviousOperationByPartNo_OpNo(opItem.PartNo, opItem.Sequence.Value);
            int? prevOpN = prevOpRec?.prevSeq;

            foundProcItem = mes_AsPLannedBOPRepo.GetAllProcessByNId(opItem.ProcessNId)?.FirstOrDefault();
            foundBoPItem = mes_AsPLannedBOPRepo.GetByNId(opItem.ProcessNId)?.FirstOrDefault();
            fOpItem = mes_AsPLannedBOPRepo.GetAllProcessToOperationLinksByOperationNId(prevOpRec?.NId)?.FirstOrDefault();
            fOpItemPrev = mes_AsPLannedBOPRepo.GetAllProcessToOperationLinksByOperationNId(prevOpRec?.PrevNId)?.FirstOrDefault();

            foundOpItem = mes_AsPLannedBOPRepo.GetAllOperationsByNId(opItem.NId)?.FirstOrDefault();
            if (foundOpItem == null)
            {
                OperationDTOCreateParameter opCrParameter = new OperationDTOCreateParameter(opItem);
                opCrParameter.ProcessId = foundProcItem?.Id;
                opCrParameter.AsPlannedBOPId = foundBoPItem?.Id;
                string foundOpItemId = mes_AsPLannedBOPRepo.UADMCreateOperation(opCrParameter)?.Id;
                foundOpItem = mes_AsPLannedBOPRepo.GetAllOperationsById(foundOpItemId)?.FirstOrDefault();

            }//if
            else
            {
                ProcessesDTOLinkOperationParameter pr_opLink = new ProcessesDTOLinkOperationParameter
                {
                    OperationId = foundOpItem?.Id,
                    ProcessId = foundProcItem?.Id,
                    Sequence = opItem.Sequence.Value,
                    AsPlannedBopId = foundBoPItem?.Id
                };
                //Связь операция процесс уже есть по этому NID
                if (fOpItem==null)
                    mes_AsPLannedBOPRepo.LinkOperation(pr_opLink);
                foundOpItem.UpdateRecord(opItem);
                OperationDTOUpdateParameter opUpParameter = new OperationDTOUpdateParameter(foundOpItem);
                opUpParameter.ProcessId = foundProcItem?.Id;
                opUpParameter.AsPlannedBOPId = foundBoPItem?.Id;
                mes_AsPLannedBOPRepo.UADMUpdateOperation(opUpParameter);
            }//else
            //Вычисление предыдущей операции от текущей
            if (prevOpN == null|| prevOpN == 0|| prevOpRec==null)
                return;
            //Создаем зависимые связи между операциями, паралельные или последовательные
            OperationStructureDependencyParameterType structDepParameter = new OperationStructureDependencyParameterType
            {
                FromLinkId = fOpItemPrev?.Id,
                ToLinkId = fOpItem?.Id,
                DependencyTypeId = "c6d21b93-ab2a-ec11-ba87-000c29a5c633",
                AsPlannedBOPId = foundBoPItem?.Id
            };
            OperationDTOCreateDependencyParameter opDepCrParameter = new OperationDTOCreateDependencyParameter(structDepParameter);
            mes_AsPLannedBOPRepo.CreateOperationStructureDependency(opDepCrParameter);

        }//CreateOrUpdateOperation


        private void CreateOrUpdateMaterialSpecification(MaterialSpecificationDTO matSpecItem)
        {
            OperationDTO foundOpItem = null;
            foundOpItem = mes_AsPLannedBOPRepo.GetAllOperationsByNId(matSpecItem.OperationNId)?.FirstOrDefault();
            DMMaterialDTO mat = mesDMMatRepo.GetByNId(matSpecItem.MaterialNId)?.FirstOrDefault();
            AsPlannedBOPDTO foundBoPItem = null;
            foundBoPItem = mes_AsPLannedBOPRepo.GetByNId(matSpecItem.AsPlannedBOP_NId)?.FirstOrDefault();
            if (mat == null || foundOpItem == null)
                return;
            MaterialSpecificationDTO foundMatSpecItem = mes_AsPLannedBOPRepo.GetAllMaterialSpecificationByOpId(foundOpItem?.Id)?
                .FirstOrDefault(x=>x.DM_MaterialId_Id==mat.Id);
            if (foundMatSpecItem == null)
            {
                MaterialSpecificationDTOCreateParameter matSpecCrPar = new MaterialSpecificationDTOCreateParameter(matSpecItem);
                matSpecCrPar.MaterialSpecification.OperationId = foundOpItem?.Id;
                matSpecCrPar.MaterialSpecification.DMMaterialId = mat?.Id;
                matSpecCrPar.MaterialSpecification.AsPlannedBopId = foundBoPItem?.Id;
                matSpecCrPar.MaterialSpecification.Quantity = new QuantityType { UoMNId = mat.Material?.UoMNId, QuantityValue = (float)matSpecItem.QuantityVal };
                mes_AsPLannedBOPRepo.CreateMaterialSpecification(matSpecCrPar);

            }//if
            else
            {
                MaterialSpecificationDTOUpdateParameter matSpecUpPar = new MaterialSpecificationDTOUpdateParameter {
                    Id = foundMatSpecItem?.Id,
                    Quantity = new QuantityType {QuantityValue=(float)matSpecItem.QuantityVal  ,UoMNId=mat.Material?.UoMNId }
                };
                mes_AsPLannedBOPRepo.UpdateMaterialSpecification(matSpecUpPar);

            }







        }//CreateOrUpdateMaterialSpecification


        /// <summary>
        /// Скрипт загрузки Процессов и операций из скл в MES
        /// </summary>
        private void ImportOperationToMes()
        {
            IEnumerable<OperationDTO> opSqlCollection = sqlOpRepo.GetAll();
            IEnumerable<ProcessesDTO> procSqlCollection = sqlProcRepo.GetAll();
            IEnumerable<MaterialSpecificationDTO> metSpecCollection =  sqlMatSpecRepo.GetAll();
            //Создаем или обновляем справочник процессов
            foreach (ProcessesDTO procItem in procSqlCollection)
            {
                CreateOrUpdateProcess(procItem);
            }//foreach

            //Создаем или обновляем справочник операций
            foreach (OperationDTO opItem in opSqlCollection)
            {
                CreateOrUpdateOperation(opItem);
            }//foreach

            foreach (MaterialSpecificationDTO matSpecItem in metSpecCollection)
            {
                CreateOrUpdateMaterialSpecification(matSpecItem);
            }//foreach




        }//ImportOperationToMes


    }
}
