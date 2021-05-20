using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public interface IResponse<T>
    {
        List<T> value { get; set; }
    }

    public class AsPlannedBOPDTOResponse: IResponse<AsPlannedBOPDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<AsPlannedBOPDTO> value { get; set;}
        public bool Succeeded;
        public string AsPlannedBOPId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class ProcessesDTOResponse: IResponse<ProcessesDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<ProcessesDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class OperationDTOResponse : IResponse<OperationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<OperationDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public List<string> OperationId;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class ProcessToOperationLinkDTOResponse: IResponse<ProcessToOperationLinkDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<ProcessToOperationLinkDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class MaterialSpecificationDTOResponse : IResponse<MaterialSpecificationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<MaterialSpecificationDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class ProcessMachineDTOResponse : IResponse<ProcessMachineDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<ProcessMachineDTO> value { get; set; }
        public bool Succeeded;
        public string Id;
        public string EquipmentSpecificationId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class MaterialSpecificationDTOCreateParameter
    {
        public String DMMaterialId;
        public QuantityType Quantity;
        public String OperationId;
        public String LogicalPosition;
        public String StepId;
        public String MaterialSpecificationTypeId;
        public String GroupId;
        public bool? AlternativeSelected;
        public String EffectivityExpression;
        public String AsPlannedBopId;
        public String UId;
    }
    public class MaterialSpecificationDTOUpdateParameter
    {
        public QuantityType Quantity;
        public String Id;
        public String LogicalPosition;
        public bool? AlternativeSelected;
    }

    public class MaterialSpecificationParameterType
    {
        public String DMMaterialId;
        public QuantityType Quantity;
        public String OperationId;
        public String LogicalPosition;
        public String StepId;
        public String MaterialSpecificationTypeId;
        public String GroupId;
        public bool? AlternativeSelected;
        public String EffectivityExpression;
        public String AsPlannedBopId;
        public String UId;

    }

    public class MaterialSpecificationDTOUpdateParameterFull
    {
        public String Id;
        public MaterialSpecificationParameterType MaterialSpecification;
    }
    
    public class MaterialSpecificationDTODeleteParameter
    {
        public String[] Ids;
    }

    public class AsPlannedBOPDTOUpdateParameter
    {
        public string AsPlannedBOPConfigurationId;
    }

    public class AsPlannedBOPDTOCreateParameter
    {
        public AsPlannedBOPDTO AsPlannedBOP;

    }
    public class AsPlannedBOPDTODeleteParameter
    {
        public string AsPlannedBOPConfigurationId;
    }
    public class ProcessesDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Revision;
        public string Plant;
        public string Description;
        public string AsPlannedBOPId;
        public String ParentProcessId;
        public string FinalMaterialId;
        public int Sequence;
        public QuantityType Quantity;
        public QuantityType MaxQuantity;
    }
    
    public class ProcessesDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
        public string Plant;
        public string FinalMaterialId;
        public int Sequence;
        public QuantityType Quantity;
        public QuantityType MaxQuantity;
        public QuantityType MinQuantity;
    }

    public class ProcessesDTOLinkOperationParameter
    {
        public string AsPlannedBOPId;
        public string OperationId;
        public string ProcessId;
        public int Sequence;
    }

    public class ProcessesDTODeleteParameter
    {
        public string Id;
    }
    public class OperationDTODeleteParameter
    {
        public string Id;
    }
    public class ProcessMachineDTODeleteParameter
    {
        public string[] Ids;
    }
    public class CreateEquipmentSpecificationDTOCreateParameter
    {
        public EquipmentSpecificationParameterType EquipmentSpecification;
        public string CorrelationId;
    }


    public class OperationParameterTypeDTO
    {
        public string NId;
        public string Name;
        public string Revision;
        public int? Sequence;
        public string Description;
        public Nullable<bool> Optional;
        public String WorkOperationId;
        public string UId;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public String RequiredInspectionRole;
        public String RequiredCertificateNId;
        public String EffectivityExpression;
        public String OperationStepCategoryId;
    
    }

    public class OperationDTOUpdateParameter
    {
        public string Id;
        public Nullable<bool> ToBeCollectedDocument;
        public OperationParameterTypeDTO Operation;
    }
    public class OperationDTOCreateParameter
    {
        public string UID;
        public string NId;
        public string Name;
        public string Description;
        public string Revision;
        public Nullable<bool> RequiredInspectionRole;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public Nullable<bool> RequiredCertificateNId;
        public string WorkOperationTypeNId;
        public string OperationStepCategoryId;
    }



    public class ProcessesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Revision{ get; set; }
        public string NId { get; set; }
        public string UId { get; set; }
        public string Plant { get; set; }
        public QuantityType Quantity{ get; set; }
        public QuantityType Volume { get; set; }
        public MaterialDTO Material { get; set; }
        public DMMaterialDTO FinalMaterialId { get; set; }
        public string FinalMaterialName { get; set; }
        public string FinalMaterialNId { get; set; }

    }


    /// <summary>
    /// Класс AsPlannedBOPDTO MES. Является базовым. 
    /// </summary>
    public class AsPlannedBOPDTO
    {
        public string Id { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public string BaselineName { get; set; }
        public String CorrelationId { get; set; }
        public String BaselineUId { get; set; }
        public string PBOPIdentID { get; set; }
        public String MasterPlanUID { get; set; }
        public string OrderId { get; set; }
        public Nullable<bool> IsOutOfDate { get; set; }
        public Nullable<bool> Completed { get; set; }
        public string[] SegregationTags { get; set; }
        public List<ProcessesDTO> Processes { get; set; }
    }
    public class WorkOperationTypeDTO
    {
        public string Id;
        public string NId;
    }
    public class OperationStepCategoryDTO
    {
        public string Id { get; set; }
        public string NId { get; set; }
        public string AId { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }

    public class OperationDTO
    {
        public string Id { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Optional { get; set; }
        public int? Sequence { get; set; }
        public String CorrelationId { get; set; }
        public string NId { get; set; }
        public string Revision { get; set; }
        public string UId { get; set; }
        public Nullable<bool> ElectronicSignatureStart { get; set; }
        public Nullable<bool> ElectronicSignaturePause { get; set; }
        public Nullable<bool> ElectronicSignatureComplete { get; set; }
        public String RequiredInspectionRole { get; set; }
        public String RequiredCertificateNId { get; set; }
        public Nullable<bool> ToBeCollectedDocument { get; set; }
        public String EffectivityExpression { get; set; }
        public Int64? EstimatedDuration_Ticks { get; set; }
        public String EstimatedDuration { get; set; }
        public String WorkOperationId_Id { get; set; }
        public String OperationStepCategoryId_Id { get; set; }
        public WorkOperationTypeDTO WorkOperationId { get; set; }
        public OperationStepCategoryDTO OperationStepCategoryId { get; set; }
        //для совместимости с скл
        public String ResourceGroup { get; set; }

    }

    public class ProcessToOperationLinkDTO
    {
        public string Id { get; set; }
        public string AId { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public String CorrelationId { get; set; }
        public int? Sequence { get; set; }
        public string UId { get; set; }
        public String EffectivityExpression { get; set; }
        public String ParentProcess_Id { get; set; }
        public String ChildOperation_Id { get; set; }
        public String AsPlannedBOP_Id { get; set; }
        public String MasterPlan_Id { get; set; }
        public OperationDTO ChildOperation { get; set; }
        public String ParentProcess_NId { get; set; }
        public String ParentProcess_Name { get; set; }
        public String ChildOperation_NId { get; set; }
        public String ChildOperation_Name { get; set; }
        public String Plant { get; set; }
    }

    public class MaterialSpecificationDTO
    {
        public string Id { get; set; }
        public string AId { get; set; }
        public Nullable<bool> IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<bool> ToBeCleaned { get; set; }
        public string UId { get; set; }
        public String EffectivityExpression { get; set; }
        public String LogicalPosition { get; set; }
        public String GroupId { get; set; }
        public Nullable<bool> AlternativeSelected { get; set; }
        public String CorrelationId { get; set; }
        public String DM_MaterialId_Id { get; set; }
        public String Operation_Id { get; set; }
        public String Step_Id { get; set; }
        public String MaterialTypeNId_Id { get; set; }
        public String AsPlannedBOP_Id { get; set; }
        public String MasterPlan_Id { get; set; }
        public QuantityType Quantity { get; set; }
        public DMMaterialDTO DM_MaterialId { get; set; }
        public MaterialDTO Material { get; set; }
        //для целей интеграции с ПБД
        public String MaterialNId { get; set; }
        public double QuantityVal { get; set; }
        public int Operation_Number { get; set; }
        public String Operation_Name { get; set; }
        public String AsPlannedBOP_NId { get; set; }

    }

    public class ProcessMachinesParameterType
    {
        public String Name { get; set; }
        public String NId { get; set; }
        public String Type { get; set; }
        public String LevelNId { get; set; }
        public String EquipmentSpecificationId { get; set; }
        public String AssociatedPrintJobFileId { get; set; }
        public String AssociatedPrintJobFileNId { get; set; }
        public String AssociatedPartProgramId { get; set; }
        public String AssociatedPartProgramNId { get; set; }
        public bool? IsWorkOperationAM { get; set; }
        public bool? IsWorkOperationCNC { get; set; }
        public String Id { get; set; }

    }

    public class ProcessMachineDTO
    {
        public String Id { get; set; }
        public ProcessMachinesParameterType result { get; set; }
    }

    public class EquipmentSpecificationParameterType
    {
        public String Type { get; set; }
        public String OperationID { get; set; }
        public String PartProgram { get; set; }
        public String EquipmentNId { get; set; }
        public String EquipmentTypeNId { get; set; }
        public String EffectivityExpression { get; set; }
        public String AsPlannedBopId { get; set; }
        public String UId { get; set; }

    }



}
