using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class AsPlannedBOPDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<AsPlannedBOPDTO> value;
        public bool Succeeded;
        public string AsPlannedBOPId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class ProcessesDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<ProcessesDTO> value;
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
        int Sequence;
        QuantityType Quantity;
        QuantityType MaxQuantity;
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

}
