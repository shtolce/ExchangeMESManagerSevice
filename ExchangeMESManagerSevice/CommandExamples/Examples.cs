using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.CommandExamples
{
    public class Examples
    {
        /*

            var command = new WorkOrderOperationDependenciesDTOCreateParameter
            {
                Dependencies = new List<WorkOOperationDependencyParameterDTO>
                {
                    new WorkOOperationDependencyParameterDTO
                    {
                         FromId="053c7b53-8a76-438d-9423-0ddbac51e607"
                        ,OperationDependencyType="AfterStart"
                        ,PartialCompleted=null
                        ,ToId="186ce7d6-b6b0-4c39-8339-4adb8a8a5e62"
                    }
                }
            };



           var command = new WorkOrderOperationDependenciesDTODeleteParameter
            {
                Dependency = new WorkOOperationDependencyParameterDTO
                {
                     FromId="053c7b53-8a76-438d-9423-0ddbac51e607"
                    ,OperationDependencyType="AfterStart"
                    ,PartialCompleted=null
                    ,ToId="186ce7d6-b6b0-4c39-8339-4adb8a8a5e62"
                }
            };


            var command = new WorkOrderOperationFromProcessOperationDTOCreateParameter
            {
                WorkOrderId = "e58f6585-09ba-4084-9939-5d228f9b8c69",
                WorkOrderOperation = new WorkOrderOperationFromOperationParameterDTO
                {
                     NId="asdasdwedwe123"
                    ,EstimatedStartTime=null
                    ,EstimatedEndTime=null
                    ,Priority=0
                    ,Name="asdasd"
                    ,OperationId="26389f96-5dff-4eca-b577-8a10c405f264"
                    ,WorkOperationTypeId=null
                    ,RequiredCertificateNId=null
                    ,RequiredInspectionRole=null
                    ,ElectronicSignatureStart=false
                    ,ElectronicSignaturePause=false
                    ,ElectronicSignatureComplete=false
                    ,ToBeCollectedDocument=false
                    ,Sequence=20
                    ,EstimatedDuration=null
                    ,OperationStepCategoryId=null
                    ,AsPlannedBopId="2f9bdf4d-a35f-4766-b00a-05507e87b48d"
                }
            };



            var command = new WorkOrderOperationDTOCreateParameter
            {
                WorkOrderId = "e58f6585-09ba-4084-9939-5d228f9b8c69",
                WorkOrderOperation = new WorkOrderOperationParameterDTO
                {
                    NId = "asd123",
                    Priority = 0,
                    Description = "asd123",
                    Name = "asd123",
                    OperationId = null,
                    WorkOperationTypeId = "f3663e25-a42e-4f31-ae45-ab8eb0ba62e7",
                    Sequence = 10,
                    OperationStepCategoryId  = "b433bc9f-8c70-4d7c-b472-0fcfe08c7d7a",

                    EstimatedDuration = null


                }
            };



            var command = new WorkOrderDTOCreateParameter
            {
                NId = "gqwtt123456",
                ProductionTypeNId = "FullQuantity",
                FinalMaterialId = "0dbfd323-15ad-4aba-8835-c49700a6182a",
                Plant = "Enterprise",
                BatchId = "MB_SF_20210427_078",
                ERPOrder = "gqwtt123456",
                InitialQuantity = 3,
                PlannedTargetQuantity = null,
                Name = "er123",
                Sequence = 1,

            };


            var command = new WorkOrderDTOCreateFromProcessParameter
            {
                NId = "qwtt123456",
                ProcessId = "2a195880-c74e-48df-81c1-7512be1e2063",
                ProductionTypeNId = "FullQuantity",
                Quantity = 5,
                AsPlannedId = "9a17c871-0686-4f75-9bff-8d9252393caa",
                FinalMaterialId = "0dbfd323-15ad-4aba-8835-c49700a6182a",
                Plant = "Enterprise",
                BatchId = "MB_SF_20210427_077",
                ERPOrder = "qwtt123456"
            };        
        
        
        var command = new WorkOrderDTOCreateFromAsPlannedBOPParameter
            {
                BaselineUId="f55df0c6-8d46-4879-a6b7-3199d01ae05b"
                ,ProductionTypeNId="FullQuantity"
                ,ERPOrder="qwe123"
            };
            var res = _MESUoWService.WorkOrdersRepository.CreateWorkOrdersFromAsPlannedBOP(command);

        
        
        var command = new ProcessesDTOLinkOperationParameter
        {

             ProcessId = "84863b87-76eb-4652-9c19-bcf86362a29f",
             OperationId = "639f69e7-e367-47f1-89c7-17a340be04a7",
             Sequence = 70,
             AsPlannedBOPId = "839a8d5b-a0bf-4524-bb3e-8b42780ba968"

        };

        var res = _AsPlannedBOPRepository.LinkOperation(command);

        var command = new ProcessesDTOUpdateParameter
        {

            Id = "b8421801-9d5e-4ce8-9c55-728e6b355c3c"
            ,Description ="888"
            ,Name="888"
            ,FinalMaterialId= "e1e8fcae-cd05-460f-b947-570d63e26b22"
            ,Plant="123"
            ,Quantity = new QuantityType {QuantityValue=1,UoMNId="n/a" }
            ,MaxQuantity = new QuantityType { QuantityValue = 1, UoMNId = "n/a" }

        };



        var command = new UoMDTOCreateParameter
        {
            NId="test123"
            ,Name = "test123"
            ,UoMDimensionId = "0f54d6c8-aa00-4a20-95ff-a45602622545"//n/a
        };
        var res = _UoMRepository.CreateUoM(command);



        var command = new DMMaterialDTOCreateParameter
        {
             MaterialId = "e9b5583c-71b5-4e76-abbe-eead97a2d379",
             LogisticClassNId = "a0524950-636c-79f1-07f7-b6970482dd22",
             MaterialClassId= "e838b8f1-ebd8-015f-2912-5f52fa87a588"
        };
        var res = _DMMaterialRepo.CreateMaterial(command);

        var command = new MaterialDTOCreateParameter
        {
            Description = "test21234",
            UseDefault = false,
            Name = "test12234",
            NId = "test12324",
            Revision = "A",
            TemplateNId = null,
            UId = "123424",
            UoMNId = "cm"
        };
        var res = _materialRepo.CreateMaterial(command);

        var commandDel = new MaterialDTOUpdateParameter
        {
            Id = "756ac014-ad22-4e45-9322-fc6a850e8064"
            , Description =" 9123123123"
            , Name = "91231231"
            , UoMNId ="%"

        };

        res = _materialRepo.UpdateMaterial(commandDel);
        */


    }
}
