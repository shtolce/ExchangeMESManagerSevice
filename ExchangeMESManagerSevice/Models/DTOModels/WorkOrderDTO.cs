using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class ToBeConsumedMaterialDTOResponse : IResponse<ToBeConsumedMaterialDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<ToBeConsumedMaterialDTO> value { get; set; }
        public bool Succeeded;
        public string WorkOrderId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class WorkOrderDTOResponse:IResponse<WorkOrderDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<WorkOrderDTO> value { get; set; }
        public bool Succeeded;
        public string WorkOrderId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class WorkOOperationDependencyDTOResponse : IResponse<WorkOOperationDependencyDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<WorkOOperationDependencyDTO> value { get; set; }
        public bool Succeeded;
        public string[] Ids;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    

    public class WorkOrderOperationDTOResponse : IResponse<WorkOrderOperationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<WorkOrderOperationDTO> value { get; set; }
        public bool Succeeded;
        public string WorkOrderId;
        public string Ids;
        public string Id;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class MaterialBatchDTOResponse : IResponse<MaterialBatchDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<MaterialBatchDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialBatchId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }


    public class TemplateToMaterialPlantDTOResponse : IResponse<TemplateToMaterialPlantDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<TemplateToMaterialPlantDTO> value { get; set; }
        public bool Succeeded;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class MaterialBatchDTOGenerateParameter
    {
        public string IdMaterialId;
        public string TemplateId;
    }


    public class WorkOrderOperationDependenciesDTOCreateParameter
    {
        public List<WorkOOperationDependencyParameterDTO> Dependencies;
    }

    public class WorkOrderOperationDependenciesDTODeleteParameter
    {
        public WorkOOperationDependencyParameterDTO Dependency;
    }
    public class WorkOrderOperationDTODeleteParameter
    {
        public string Id;
    }

    public class WorkOrderOperationDTOUpdateParameter
    {
        public string Id;
        public DateTimeOffset? EstimatedEndTime;
        public DateTimeOffset? EstimatedStartTime;
        public string Description;
        public string Name;
        public String RequiredCertificateNId;
        public String RequiredInspectionRole;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public Nullable<bool> ToBeCollectedDocument;
        public String WorkOperationTypeId;
        public String OperationStepCategoryId;
        public TimeSpan? EstimatedDuration;

    }

    /// <summary>
    /// Для записи одиночной операции
    /// </summary>
    public class WorkOrderOperationDTOCreateParameter
    {
        public string WorkOrderId;
        public WorkOrderOperationParameterDTO WorkOrderOperation;
        public String DependencyType;
    }
    /// <summary>
    /// Для записи массива операций
    /// </summary>
    public class WorkOrderOperationsDTOCreateParameter
    {
        public string WorkOrderId;
        public List<WorkOrderOperationParameterDTO> WorkOrderOperation;
        public String DependencyType;
    }

    public class WorkOrderOperationFromProcessOperationDTOCreateParameter
    {
        public string WorkOrderId;
        public WorkOrderOperationFromOperationParameterDTO WorkOrderOperation;
        public String DependencyType;
    }

    public class WorkOrderDTOCreateParameter
    {
        public string NId;
        public string ProductionTypeNId;
        public double InitialQuantity;
        public double? PlannedTargetQuantity;
        public string FinalMaterialId;
        public string Plant;
        public string Name;
        public int Sequence;
        public string BatchId;
        public string ERPOrder;
    }

    public class WorkOrderDTOCreateFromAsPlannedBOPParameter
    {
        public string BaselineUId;
        public string ProductionTypeNId;
        public string ERPOrder;
    }
    public class WorkOrderDTOCreateFromProcessParameter
    {
        public string ERPOrder;
        public string NId;
        public string ProcessId;
        public string ProductionTypeNId;
        public double Quantity;
        public string AsPlannedId;
        public string FinalMaterialId;
        public string Plant;
        public string BatchId;
    }

    public class WorkOrderDTOUpdateParameter
    {
        public string NId;
        public string Name;
        public string ParentBatch;
        public string ProductionTypeNId;
        public string ERPOrder;
        public string BatchId;
        public double? PlannedTargetQuantity;
        public DateTimeOffset? DueDate;
        public string Id;
        public DateTimeOffset? EstimatedEndTime;
        public double? InitialQuantity;
        public string FinalMaterialId;
}

    public class WorkOrderDTODeleteParameter
    {
        public string Id;
    }
    public class MaterialTrackingUnitDTO
    {
        public string Code;
    }
    public class DM_MaterialTrackingUnitDTO
    {
        public string Id;
        public string AId;
        public bool? IsFrozen;
        public int ConcurrencyVersion;
        public bool? IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool? IsLocked;
        public bool? ToBeCleaned;
        public bool? IsReserved;
        public int? ActiveNonConformanceNumber;
        public String BufferNId;
        public string DM_MaterialId_Id;
        public String ParentDM_MTU_Id;
        public string MaterialTrackingUnit_Id;
        public QuantityType Weight;
        public QuantityType Volume;
        public MaterialTrackingUnitDTO MaterialTrackingUnit;
    }

    public class ProducedMaterialItemDTO
    {
        public string Id;
        public string AId;
        public bool? IsFrozen;
        public int? ConcurrencyVersion;
        public int? IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool? IsLocked;
        public bool? ToBeCleaned;
        public string DM_MaterialTrackingUnit_Id;
        public string WorkOrder_Id;
        public DM_MaterialTrackingUnitDTO DM_MaterialTrackingUnit;
    }
    public class MaterialBatchDTO
    {
        public string Id;

    }


    
    public class StatusDTO
    {
        public string StateMachineNId;
        public string StatusNId;
    }
    public class ProductionTypeDTO
    {
        public string NId;
    }

    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели DMWorkOrder
    /// </summary>
    public class WorkOrderDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public DateTimeOffset? ActualEndTime;
        public DateTimeOffset? ActualStartTime;
        public string Name;
        public string Notes;
        public string ParentBatch;
        public string PBOPIdentID;
        public string Plant;
        public string AsPlanned;
        public DateTimeOffset? CreationDate;
        public DateTimeOffset? DueDate;
        public string Enterprise;
        public string ERPOrder;
        public DateTimeOffset? EstimatedEndTime;
        public DateTimeOffset? EstimatedStartTime;
        public double? InitialQuantity;
        public string NId;
        public string ProcessNId;
        public string ProcessRevision;
        public string ProcessUId;
        public DateTimeOffset? SchedulingDate;
        public int? Sequence;
        public string ConfigurationParameter;
        public string RoutingID;
        public string TargetProductID;
        public double? PlannedTargetQuantity;
        public double? ActualTargetQuantity;
        public double? TargetQuantity;
        public double PoC;
        public int? Priority;
        public bool IsUnderScheduling;
        public double? ProducedQuantity;
        public double? ReworkedQuantity;
        public double? ScrappedQuantity;
        public string Process_Id;
        public ProcessesDTO Process;
        public WorkOrderDTO ParentOrder;
        public WorkOrderDTO ReworkOfOrder;
        public string FinalMaterial_Id;
        public String ReworkOfOrder_Id;
        public String ParentOrder_Id;
        public string ProductionType_Id;
        public StatusDTO Status;
        public StatusDTO PreviousStatus;
        public DMMaterialDTO FinalMaterial;
        public ProductionTypeDTO ProductionType;
        public List<WorkOrderOperationDTO> WorkOrderOperations;
        public string[] SegregationTags;
        public ProducedMaterialItemDTO[] ProducedMaterialItems;

    }
    public class ToBeUsedMachineDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public String Machine;

        public String EquipmentType;
        public String PartProgram;
        public String PrintJobFile;
        public bool? Preferred;
        public String WorkOrderOperation_Id;
    }
    public class WorkOrderOperationDTO
    {
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public int? ActiveNonConformanceNr;
        public DateTimeOffset? ActualEndTime;
        public DateTimeOffset? ActualStartTime;
        public double? AvailableQuantity;
        public string Description;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public DateTimeOffset? EstimatedEndTime;
        public DateTimeOffset? EstimatedStartTime;
        public DateTimeOffset? LastPauseTime;
        public string Name;
        public string NId;
        public String OperationNId;
        public String OperationRevision;
        public String OperationUId;
        public double? PartialWorkedQuantity;
        public double? ProducedQuantity;
        public String RequiredCertificateNId;
        public double? ReWorkedQuantity;
        public String RequiredInspectionRole;
        public double? ScrappedQuantity;
        public double? TargetQuantity;
        public Nullable<bool> ToBeCollectedDocument;
        public String OperationOccurrenceUId;
        public String ERPConfirmationId;
        public Int64? EstimatedDuration_Ticks;
        public String EstimatedDuration;
        public Int64? ExecutionDuration_Ticks;
        public String ExecutionDuration;
        public Int64? PauseDuration_Ticks;
        public String PauseDuration;
        public bool? IsReady;
        public bool? Optional;
        public int Priority;
        public int Sequence;
        public bool? Skippable;
        public bool? WaitingForInspection;
        public String Operation_Id;
        public String WorkOperationType_Id;
        public String OperationStepCategoryId_Id;
        public String WorkOrder_Id;
        public WorkOperationTypeDTO WorkOperationType;
        public OperationStepCategoryDTO OperationStepCategoryId;
        public WorkOrderDTO WorkOrder;
        public StatusDTO Status;
        public StatusDTO PreviousStatus;
        public List<ToBeConsumedMaterialDTO> ToBeConsumedMaterials;
        public ToBeUsedMachineDTO[] ToBeUsedMachines;
    }

    public class WorkOrderOperationParameterDTO
    {
        public string NId;
        public DateTimeOffset? EstimatedStartTime;
        public DateTimeOffset? EstimatedEndTime;
        public int Priority;
        public string Description;
        public string Name;
        public String OperationId;
        public String WorkOperationTypeId;
        public String RequiredCertificateNId;
        public String RequiredInspectionRole;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public Nullable<bool> ToBeCollectedDocument;
        public int Sequence;
        public TimeSpan? EstimatedDuration;
        public String OperationStepCategoryId;
    }

    public class WorkOOperationDependencyParameterDTO
    {
        public bool? PartialCompleted;
        public String FromId;
        public String ToId;
        public String OperationDependencyType;
    
    }

    public class WorkOrderOperationFromOperationParameterDTO
    {
        public string NId;
        public DateTimeOffset? EstimatedStartTime;
        public DateTimeOffset? EstimatedEndTime;
        public int Priority;
        public string Name;
        public String OperationId;
        public String WorkOperationTypeId;
        public String RequiredCertificateNId;
        public String RequiredInspectionRole;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public Nullable<bool> ToBeCollectedDocument;
        public int Sequence;
        public TimeSpan? EstimatedDuration;
        public String OperationStepCategoryId;
        public String AsPlannedBopId;
    }


    public class WorkOOperationDependencyDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public bool IsLocked;
        public bool ToBeCleaned;
        public String DependencyType;
        public bool? WorkOOperationDependency;
        public String FromWOO_Id;
        public String ToWOO_Id;
        public WorkOrderOperationDTO FromWOO;
        public WorkOrderOperationDTO ToWOO;
        public WorkOrderDTO WorkOrder;
    }




    public class WorkOrderOperationFromProcessOperationDTO
    {
        public string NId;
        public DateTimeOffset? EstimatedStartTime;
        public DateTimeOffset? EstimatedEndTime;
        public int Priority;
        public string Name;
        public String OperationId;
        public String WorkOperationTypeId;
        public String RequiredCertificateNId;
        public String RequiredInspectionRole;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public Nullable<bool> ToBeCollectedDocument;
        public int Sequence;
        public TimeSpan EstimatedDuration;
        public String OperationStepCategoryId;
        public String AsPlannedBopId;
    }




    public class ToBeConsumedMaterialDTO
    {
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public string Name;
        public String DCDRuntimeTask;
        public String DCDTask;
        public String FAIRuntimeTask;
        public String GroupId;
        public String LogicalPosition;
        public String MaterialSpecificationType;
        public String PrekitSerialNumber;
        public string NId;
        public double? Quantity;
        public bool? AlternativeSelected;
        public int Sequence;
        public string MaterialDefinition_Id;
        public string WorkOrderOperation_Id;
        public String WorkOrderStep_Id;
        public WorkOrderOperationDTO WorkOrderOperation;
        public DMMaterialDTO MaterialDefinition;
    }

    public class TemplateToMaterialPlantDTO
    {
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public string EquipmentNId;
        public string DM_Material;
        public string Template_Id;
        public TemplateDTO Template;
        public string[] SegregationTags;
    }

    public class TemplateDTO
    {
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public string NId;
        public String EditingUser;
        public Nullable<bool> Editing;
        public string TemplateType_Id;
        public TemplateTypeDTO TemplateType;
    }

    public class TemplateTypeDTO
    {
        public string Id;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public string NId;
    }







}











