using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeMESManagerSevice.CommandExamples
{
    public class Examples
    {
        /*

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
