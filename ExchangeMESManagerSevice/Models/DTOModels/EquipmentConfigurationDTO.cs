using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class EquipmentConfigurationDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentConfigurationDTO> value;
        public bool Succeeded;
        public string EquipmentConfigurationId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class EquipmentConfigurationDTOUpdateParameter
    {
        public string Name;
        public string Description;
        public string LevelNId;
        public string Id;
    }

    public class EquipmentConfigurationDTOCreateParameter
    {
        public string LevelNId;
        public string NId;
        public string Name;
        public string Description;
        public string EquipmentTypeNId;
        public String LocationNId;
    }
    public class EquipmentConfigurationDTODeleteParameter
    {
        public string Id;
    }


    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели EquipmentConfiguration
    /// </summary>
    public class EquipmentConfigurationDTO
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
        public bool IsCurrent;
        public string UId;
        public string NId;
        public string Name;
        public string Description;
        public string UoMNId;
        public String TemplateNId;
        public String WorkCalendarNId;
        public String LocationNId;
        public String EquipmentConfigurationId;
        public String LevelNId;
    }
    ///sit-svc/Application/Equipment/odata/EquipmentConfiguration

}
