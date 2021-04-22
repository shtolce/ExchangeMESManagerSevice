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


    public class ProcessesDTO
    {
        public string Id;
        public string Name;
        public string Revision;
        public string NId;
        public string UId;
        public string Plant;
        public QuantityType Quantity;
        public QuantityType Volume;
        public MaterialDTO Material;
        public DMMaterialDTO FinalMaterialId;

    }


/// <summary>
/// Класс AsPlannedBOPDTO MES. Является базовым. 
/// </summary>
    public class AsPlannedBOPDTO
    {
        public string Id;
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
        public string BaselineName;
        public String CorrelationId;
        public String BaselineUId;
        public string PBOPIdentID;
        public String MasterPlanUID;
        public string OrderId;
        public Nullable<bool> IsOutOfDate;
        public Nullable<bool> Completed;
        public string[] SegregationTags;
        public List<ProcessesDTO> Processes;
    }
    public class WorkOperationTypeDTO
    {
        public string Id;
        public string NId;
    }
    public class OperationStepCategoryDTO
    {
        public string Id;
        public string NId;
        public string AId;
        public Nullable<bool> IsFrozen;
        public int ConcurrencyVersion;
        public Nullable<bool> IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;
        public string OptimisticVersion;
        public String ConcurrencyToken;
        public Nullable<bool> IsLocked;
        public Nullable<bool> ToBeCleaned;
        public string Description;
        public string Name;

    }



    public class OperationDTO
    {
        public string Id;
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
        public string Description;
        public Nullable<bool> Optional;
        public int? Sequence;
        public String CorrelationId;
        public string NId;
        public string Revision;
        public string UId;
        public Nullable<bool> ElectronicSignatureStart;
        public Nullable<bool> ElectronicSignaturePause;
        public Nullable<bool> ElectronicSignatureComplete;
        public String RequiredInspectionRole;
        public String RequiredCertificateNId;
        public Nullable<bool> ToBeCollectedDocument;
        public String EffectivityExpression;
        public Int64? EstimatedDuration_Ticks;
        public String EstimatedDuration;
        public String WorkOperationId_Id;
        public String OperationStepCategoryId_Id;
        public WorkOperationTypeDTO WorkOperationId;
        public OperationStepCategoryDTO OperationStepCategoryId;
    }



    public class ProcessToOperationLinkDTO
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
        public String CorrelationId;
        public int? Sequence;
        public string UId;
        public String EffectivityExpression;
        public String ParentProcess_Id;
        public String ChildOperation_Id;
        public String AsPlannedBOP_Id;
        public String MasterPlan_Id;
        public OperationDTO ChildOperation;
    }






}
