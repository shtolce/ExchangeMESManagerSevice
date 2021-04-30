using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class EquipmentConfigurationDTOResponse:IResponse<EquipmentConfigurationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentConfigurationDTO> value { get; set; };
        public bool Succeeded;
        public string EquipmentConfigurationId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }
    public class EquipmentGroupConfigurationDTOResponse : IResponse<EquipmentGroupConfigurationDTO>
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<EquipmentGroupConfigurationDTO> value { get; set; };
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



    public class EquipmentGroupConfigurationDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
    }

    public class EquipmentGroupConfigurationDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Description;
    }
    public class EquipmentGroupConfigurationDTODeleteParameter
    {
        public string Id;
    }

    public class EquipmentGroupConfigurationDTOAssociateParameter
    {
        public string EquipmentGroupConfigurationId;
        public string[] EquipmentConfigurationIds;
    }

    public class EquipmentGroupConfigurationDTO
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
        public String Category { get; set; }
        public List<EquipmentConfigurationDTO> EquipmentConfigurations;

    }


    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели EquipmentConfiguration
    /// </summary>
    public class EquipmentConfigurationDTO
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
        public bool IsCurrent { get; set; }
        public string UId { get; set; }
        public string NId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UoMNId { get; set; }
        public String TemplateNId { get; set; }
        public String WorkCalendarNId { get; set; }
        public String LocationNId { get; set; }
        public String EquipmentConfigurationId { get; set; }
        public String EquipmentTypeNId { get; set; }
        public String LevelNId { get; set; }
    }
    ///sit-svc/Application/Equipment/odata/EquipmentConfiguration

}
