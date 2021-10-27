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

        public EquipmentDTOUpdateParameter(EquipmentDTO eq)
        {
            EquipmentConfigurationId = eq.EquipmentConfigurationId;
        }
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

        public EquipmentDTOCreateParameter(EquipmentDTO eq)
        {
            UseDefault = true;
            NId = eq.NId;
            Revision = eq.Revision;
            UId = eq.UId;
            Name = eq.Name;
            Description = eq.Description;
            UoMNId = eq.UoMNId;
            TemplateNId = eq.TemplateNId;
        }
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
        public string Id { get; set; }
        public string AId { get; set; }
        public bool IsFrozen { get; set; }
        public int ConcurrencyVersion { get; set; }
        public int IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn{ get; set; }
        public string EntityType { get; set; }
        public string OptimisticVersion { get; set; }
        public String ConcurrencyToken { get; set; }
        public bool IsLocked { get; set; }
        public bool ToBeCleaned { get; set; }
        public string Revision { get; set; }
        public String SourceRevision { get; set; }
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
        public String LevelNId { get; set; }
        public StatusType Status { get; set; }
        public void UpdateRecord(EquipmentDTO newEq)
        {
            this.AId = newEq.AId;
            this.IsFrozen = newEq.IsFrozen;
            this.ConcurrencyVersion = newEq.ConcurrencyVersion;
            this.IsDeleted = newEq.IsDeleted;
            this.CreatedOn = newEq.CreatedOn;
            this.LastUpdatedOn = newEq.LastUpdatedOn;
            this.EntityType = newEq.EntityType;
            this.OptimisticVersion = newEq.OptimisticVersion;
            this.ConcurrencyToken = newEq.ConcurrencyToken;
            this.IsLocked = newEq.IsLocked;
            this.ToBeCleaned = newEq.ToBeCleaned;
            this.Revision = newEq.Revision;
            this.SourceRevision = newEq.SourceRevision;
            this.IsCurrent = newEq.IsCurrent;
            this.UId = newEq.UId;
            this.NId = newEq.NId;
            this.Name = newEq.Name;
            this.Description = newEq.Description;
            this.UoMNId = newEq.UoMNId;
            this.TemplateNId = newEq.TemplateNId;
            this.WorkCalendarNId = newEq.WorkCalendarNId;
            this.LocationNId = newEq.LocationNId;
            //this.EquipmentConfigurationId = newEq.EquipmentConfigurationId;
            this.LevelNId = newEq.LevelNId;
            this.Status = newEq.Status;

        }


    }
    //GET /sit-svc/Application/Equipment/odata/Equipment?$top=24&$skip=0&$orderby=NId%20asc&$count=true HTTP/1.1


}
