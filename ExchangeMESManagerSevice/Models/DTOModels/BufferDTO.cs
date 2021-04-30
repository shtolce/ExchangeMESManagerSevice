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

    public class BufferDefinitionDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<BufferDefinitionDTO> value;
        public bool Succeeded;
        public string Id;
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
        public string NId;
        public string Name;
        public string Description;
        public String BufferDefinition;
        public String LocationNId;
        public String Status;
        public QuantityType Quantity;
        public DateTimeOffset? ValidFrom;
        public DateTimeOffset? ValidTo;

    }
    public class BufferDTODeleteParameter
    {
        public string Id;
    }

    public class BufferDefinitionDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Version;
        public string CapacityType;
        public bool? IsValid;
        public QuantityType Quantity;
    }
    public class BufferDefinitionDTODeleteParameter
    {
        public string Id;
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
        public string Id { get; set; }
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        public string NId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public bool? IsValid { get; set; }
        public String CapacityType_Id { get; set; }
        public QuantityType MaxQty { get; set; }
        public QuantityType MaxWeight { get; set; }
        public QuantityType MaxVolume { get; set; }
    }


    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели Buffer
    /// </summary>
    public class BufferDTO
    {
        public string Id { get; set; }
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        public string Description { get; set; }
        public String EquipmentNId { get; set; }
        public String EquipmentName { get; set; }
        public String Name { get; set; }
        public String NId { get; set; }
        public DateTimeOffset? ValidityFrom { get; set; }
        public DateTimeOffset? ValidityTo { get; set; }
        public String BufferDefinition_Id { get; set; }
        public String CapacityType_Id { get; set; }
        public QuantityType MaxQty { get; set; }
        public QuantityType MaxVolume { get; set; }
        public QuantityType MaxWeight { get; set; }
        public StatusDTO Status { get; set; }
        public BufferDefinitionDTO BufferDefinition { get; set; }
        public CapacityTypeDTO CapacityType { get; set; }
    }

}
