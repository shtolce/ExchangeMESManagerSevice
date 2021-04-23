using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class MaterialDTOResponse:IResponse<MaterialDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<MaterialDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class BoMDTOResponse : IResponse<BoMDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<BoMDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class BoMItemDTOResponse : IResponse<BoMItemDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<BoMItemDTO> value { get; set; }
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class BoMItemDTOCreateParameter
    {
        public string NId;
        public String GroupName;
        public QuantityType Quantity;
        public int? LogicalPosition;
        public String MaterialDefinition;
        public String BoM;
        public String GroupType;
    }
    public class BoMItemDTODeleteParameter
    {
        public String[] Ids;
    }



    public class BoMDTOCreateParameter
    {
        public string NId;
        public string Version;
        public string Name;
        public string Description;
        public QuantityType Quantity;
        public DateTimeOffset? ValidFrom;
        public DateTimeOffset? ValidTo;
        public String MaterialDefinition;
    }

    public class BoMDTOChangeStatusParameter
    {
        public string BoMId;
        public String StatusNId = "Obsolete";
    }

    public class MaterialDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
        public string UoMNId;
    }

    public class MaterialDTOCreateParameter
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
    public class MaterialDTODeleteParameter
    {
        public string Id;
    }

    public class BoMDTO
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
        public string Name;
        public string Description;
        public int Priority;
        public DateTimeOffset? ValidityFrom;
        public DateTimeOffset? ValidityTo;
        public string Version;
        public string NId;
        public String MaterialDefinition_Id;
        public StatusType Status;
        public QuantityType Quantity;
        public string[] SegregationTags;
        public DMMaterialDTO MaterialDefinition;
    }
    public class BoMItemGroupTypeDTO
    {
        public string NId;
    }


    public class BoMItemDTO
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
        public string NId;
        public string BoM_Id;
        public String BoMItemBoM_Id;
        public String GroupType_Id;
        public String MaterialDefinition_Id;
        public QuantityType Quantity;
        public DMMaterialDTO MaterialDefinition;
        public BoMDTO BoMItemBoM;
        public BoMItemGroupTypeDTO GroupType;

    }





    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели DMMaterial
    /// </summary>
    public class MaterialDTO
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
        public string Revision;
        public String SourceRevision;
        public bool IsCurrent;
        public string UId;
        public string NId;
        public string Name;
        public string Description;
        public string UoMNId;
        public String TemplateNId;
    }
}
