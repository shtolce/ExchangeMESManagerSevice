using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class MaterialClassDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<MaterialClassDTO> value;
        public bool Succeeded;
        public string MaterialGroupIds;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class MaterialClassDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
    }
    
    public class MaterialClassDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Description;
    }
    public class MaterialClassDTODeleteParameter
    {
        public string MaterialGroupIds;
    }
    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели DMMaterial
    /// </summary>
    public class MaterialClassDTO
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

    }
}
