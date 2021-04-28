using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class BufferDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<BufferDTO> value;
        public bool Succeeded;
        public string BufferId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class BufferDTOUpdateParameter
    {
        public string BufferConfigurationId;
    }

    public class BufferDTOCreateParameter
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
    public class BufferDTODeleteParameter
    {
        public string BufferConfigurationId;
    }

    public class CapacityTypeDTO
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
    }


    public class BufferDefinitionDTO
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
        public string Name;
        public string Description;
        public string Version;
        public bool? IsValid;
        public String CapacityType_Id;
        public QuantityType MaxQty;
        public QuantityType MaxWeight;
        public QuantityType MaxVolume;
    }


    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели Buffer
    /// </summary>
    public class BufferDTO
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
        public string Description;
        public String EquipmentNId;
        public String EquipmentName;
        public String Name;
        public String NId;
        DateTimeOffset? ValidityFrom;
        DateTimeOffset? ValidityTo;
        public String BufferDefinition_Id;
        public String CapacityType_Id;
        public QuantityType MaxQty;
        public QuantityType MaxVolume;
        public QuantityType MaxWeight;
        public StatusDTO Status;
        public BufferDefinitionDTO BufferDefinition;
        public CapacityTypeDTO CapacityType;
    }

}
