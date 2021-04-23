using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class SupplierDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        [JsonProperty(PropertyName = "@odata.count")]
        public int ODataCount;
        public List<SupplierDTO> value;
        public bool Succeeded;
        public string SupplierId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class SupplierDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Description;
    }
    public class SupplierDTODeleteParameter
    {
        public string[] SupplierIds;
    }
    /// <summary>
    /// Класс материалов MES. Является базовым. Все его доп свойства расширены в другой модели DMMaterial
    /// </summary>
    public class SupplierDTO
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
        public string[] SegregationTags;
    }
}
