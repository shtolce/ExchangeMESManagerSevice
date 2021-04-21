using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Models.DTOModels
{
    public class UoMDTOResponse
    {
        [JsonProperty(PropertyName = "@odata.context")]
        public string @ODataContext;
        public List<UoMDTO> value;
        public bool Succeeded;
        public string UoMId;
        public List<string> PropertyIds;
        public object Error;
        public object SitUafExecutionDetail;
    }

    public class UoMDTOUpdateParameter
    {
        public string Id;
        public string Name;
        public string Description;
    }

    public class UoMDTOCreateParameter
    {
        public string NId;
        public string Name;
        public string Description;
        public string UoMDimensionId;
    }
    public class UoMDTODeleteParameter
    {
        public string Id;
    }

    public class UoMDimension
    {
        public string NId;
        public string Name;
        public string Description;
        public bool IsHidden;
        public bool IsSystemDefined;
    }


    /// <summary>
    /// Класс материалов MES. UoM
    /// </summary>
    public class UoMDTO
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
        public String SourceRevision;
        public bool IsCurrent;
        public string NId;
        public string Name;
        public string Description;
        public bool IsHidden;
        public bool IsSystemDefined;
        public string UoMDimension_Id;
        public String UoMBase_Id;
        UoMDimension UoMDimension;
    }







}
