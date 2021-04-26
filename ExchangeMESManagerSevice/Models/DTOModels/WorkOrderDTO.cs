using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
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
    public class WorkOrderOperationDTOResponse : IResponse<WorkOrderOperationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<WorkOrderOperationDTO> value { get; set; }
        public bool Succeeded;
        public string WorkOrderId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class WorkOrderDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
        public string UoMNId;
    }

    public class WorkOrderDTOCreateParameter
    {
        public bool UseDefault;
        public string NId;
        public string Revision;
        public string UId;
        public string Name;
        public string Description;
        public string UoMNId;
        public String TemplateNId;
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
        public ToBeUsedMachineDTO[] ToBeUsedMachines;
    }


}
