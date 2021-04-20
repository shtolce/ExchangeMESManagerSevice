using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class MaterialDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<MaterialDTO> value;
        public bool Succeeded;
        public string MaterialId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
}

    public class MaterialDTOParameter
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

    public class MaterialDTO
    {
        public string Id;
        public string AId;
        public bool IsFrozen;
        public int ConcurrencyVersion;
        public int IsDeleted;
        public DateTime CreatedOn;
        public DateTime LastUpdatedOn;
        public string EntityType;//"Siemens.SimaticIT.MasterData.MAT_MS.MSModel.DataModel.Material"
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
