using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class EquipmentDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentDTO> value;
        public bool Succeeded;
        public string EquipmentId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class EquipmentDTOUpdateParameter
    {
        public string EquipmentConfigurationId;
    }

    public class EquipmentDTOCreateParameter
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
    public class EquipmentDTODeleteParameter
    {
        public string EquipmentConfigurationId;
    }

    public class StatusType
    {
        public string StateMachineNId;
        public string StatusNId;
    }

    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели Equipment
    /// </summary>
    public class EquipmentDTO
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
        public String WorkCalendarNId;
        public String LocationNId;
        public String EquipmentConfigurationId;
        public String LevelNId;
        StatusType Status;


    }
    //GET /sit-svc/Application/Equipment/odata/Equipment?$top=24&$skip=0&$orderby=NId%20asc&$count=true HTTP/1.1

}
