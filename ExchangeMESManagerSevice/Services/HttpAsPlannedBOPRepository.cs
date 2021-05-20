using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.CommandModels;
using ExchangeMESManagerSevice.Models.DTOModels;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace ExchangeMESManagerSevice.Services
{
    public class HttpAsPlannedBOPRepository
    {
        private AuthorizationMesService _authService;

        public HttpAsPlannedBOPRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public AsPlannedBOPDTOResponse DeleteAsPlannedBOP(AsPlannedBOPDTODeleteParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTODeleteParameter, AsPlannedBOPDTOResponse>(com, "DeleteAsPlannedBOP"); ;
        }

        public AsPlannedBOPDTOResponse CreateAsPlannedBOP(AsPlannedBOPDTOCreateParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTOCreateParameter, AsPlannedBOPDTOResponse>(com, "CreateAsPlannedBOP"); ;
        }
        /// <summary>
        /// Не используется
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public AsPlannedBOPDTOResponse UpdateAsPlannedBOP(AsPlannedBOPDTOUpdateParameter com)
        {
            return ExecuteCommand<AsPlannedBOPDTOUpdateParameter, AsPlannedBOPDTOResponse>(com, "UpdateAsPlannedBOP");
        }

        public ProcessesDTOResponse CreateProcess(ProcessesDTOCreateParameter com)
        {
            return ExecuteCommand<ProcessesDTOCreateParameter, ProcessesDTOResponse>(com, "UADMCreateProcess"); 
        }

        public MaterialSpecificationDTOResponse CreateMaterialSpecification(MaterialSpecificationDTOCreateParameter com)
        {
            return ExecuteCommand<MaterialSpecificationDTOCreateParameter, MaterialSpecificationDTOResponse>(com, "UADMCreateMaterialSpecification");
        }

        public MaterialSpecificationDTOResponse UpdateMaterialSpecification(MaterialSpecificationDTOUpdateParameter com)
        {
            return ExecuteCommand<MaterialSpecificationDTOUpdateParameter, MaterialSpecificationDTOResponse>(com, "UADMUpdateMaterialSpecification");
        }

        public MaterialSpecificationDTOResponse UpdateMaterialSpecificationFull(MaterialSpecificationDTOUpdateParameterFull com)
        {
            return ExecuteCommand<MaterialSpecificationDTOUpdateParameterFull, MaterialSpecificationDTOResponse>(com, "UpdateMaterialSpecification");
        }


        public MaterialSpecificationDTOResponse DeleteMaterialSpecificationList(MaterialSpecificationDTODeleteParameter com)
        {
            return ExecuteCommand<MaterialSpecificationDTODeleteParameter, MaterialSpecificationDTOResponse>(com, "DeleteMaterialSpecificationList");
        }

        public ProcessesDTOResponse UpdateProcess(ProcessesDTOUpdateParameter com)
        {
            return ExecuteCommand<ProcessesDTOUpdateParameter, ProcessesDTOResponse>(com, "UADMUpdateProcess"); 
        }
        public ProcessesDTOResponse DeleteProcess(ProcessesDTODeleteParameter com)
        {
            return ExecuteCommand<ProcessesDTODeleteParameter, ProcessesDTOResponse>(com, "DeleteProcessFromCatalogue"); 
        }
        public ProcessesDTOResponse LinkOperation(ProcessesDTOLinkOperationParameter com)
        {
            return ExecuteCommand<ProcessesDTOLinkOperationParameter, ProcessesDTOResponse>(com, "LinkOperationToProcess"); 
        }
        public ProcessesDTOResponse UnlinkOperation(ProcessesDTOLinkOperationParameter com)
        {
            return ExecuteCommand<ProcessesDTOLinkOperationParameter, ProcessesDTOResponse>(com, "UnlinkOperationToProcess"); 
        }
        public OperationDTOResponse UADMCreateOperationInCatalogue(OperationDTOCreateParameter com)
        {
            return ExecuteCommand<OperationDTOCreateParameter, OperationDTOResponse>(com, "UADMCreateOperationInCatalogue"); 
        }
        public OperationDTOResponse UADMUpdateOperationInCatalogue(OperationDTOUpdateParameter com)
        {
            return ExecuteCommand<OperationDTOUpdateParameter, OperationDTOResponse>(com, "UpdateOperation"); 
        }
        public OperationDTOResponse UADMDeleteOperationInCatalogue(OperationDTODeleteParameter com)
        {
            return ExecuteCommand<OperationDTODeleteParameter, OperationDTOResponse>(com, "DeleteOperationFromCatalogue"); 
        }
        public ProcessMachineDTOResponse DeleteEquipmentSpecificationList(ProcessMachineDTODeleteParameter com)
        {
            return ExecuteCommand<ProcessMachineDTODeleteParameter, ProcessMachineDTOResponse>(com, "UADMDeleteEquipmentSpecificationList");
        }
        public ProcessMachineDTOResponse CreateEquipmentSpecification(CreateEquipmentSpecificationDTOCreateParameter com)
        {
            return ExecuteCommand<CreateEquipmentSpecificationDTOCreateParameter, ProcessMachineDTOResponse>(com, "CreateEquipmentSpecification");
        }

        
        private D ExecuteCommand<T,D>(T com,string commandName)
        {
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/AppU4DM/odata/{commandName}") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            Command<T> comTest = new Command<T>()
            {
                command = com
            };
            string parameters = JsonConvert.SerializeObject(comTest);
            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentLength = byteArray.Length;
            webRequest.Headers.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            Stream postStream = webRequest.GetRequestStream();
            postStream = webRequest.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();

            WebResponse response;
            try
            {
                response = webRequest.GetResponse();
            }
            catch (WebException ex)
            {
                using (var reader1 = new StreamReader(ex.Response.GetResponseStream()))
                {
                    var testErr = reader1.ReadToEnd();
                    var serStatusErr = JsonConvert.DeserializeObject<D>(testErr);
                    return serStatusErr;
                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<D>(responseFromServer);
            return serStatus2;
        }

        public List<T> Get<T,D>(string urlProfile) where D:IResponse<T>
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<T>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<D>());
            var res = content.Result;
            return res.value;

        }

        public List<AsPlannedBOPDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/AsPlannedBOP?$count=true&$filter=Processes/any()&$expand=Processes($expand=FinalMaterialId($expand=Material($select=NId)))";
            return Get<AsPlannedBOPDTO, AsPlannedBOPDTOResponse>(urlProfile);
        }

        public List<AsPlannedBOPDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/AsPlannedBOP?$count=true&$filter=BaseLineName eq '{NId}' & Processes/any()&$expand=Processes($expand=FinalMaterialId($expand=Material($select=NId)))";
            return Get<AsPlannedBOPDTO, AsPlannedBOPDTOResponse>(urlProfile);
        }
        public List<ProcessToOperationLinkDTO> GetAllProcessToOperationLinks()
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/ProcessToOperationLink?$count=true&$expand=ChildOperation($expand=WorkOperationId($select=Id,NId),OperationStepCategoryId)";
            return Get<ProcessToOperationLinkDTO, ProcessToOperationLinkDTOResponse>(urlProfile);
        }
        public List<ProcessToOperationLinkDTO> GetAllProcessToOperationLinksByBOPId(string ProcessId,string BOPId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/ProcessToOperationLink?$count=true&$expand=ChildOperation($expand=WorkOperationId($select=Id,NId),OperationStepCategoryId)&$filter=AsPlannedBOP_Id eq {BOPId} and ParentProcess_Id eq {ProcessId}";
            return Get<ProcessToOperationLinkDTO, ProcessToOperationLinkDTOResponse>(urlProfile);
        }
        public List<OperationDTO> GetAllOperations()
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Operation?$count=true&$expand=WorkOperationId,OperationStepCategoryId";
            return Get<OperationDTO, OperationDTOResponse>(urlProfile);
        }
        public List<OperationDTO> GetAllOperationsById(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Operation?$count=true&$expand=WorkOperationId,OperationStepCategoryId&$filter=Id eq {Id}";
            return Get<OperationDTO, OperationDTOResponse>(urlProfile);
        }

        public List<MaterialSpecificationDTO> GetAllMaterialSpecifications()
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/MaterialSpecification?$top=10&$skip=0&$count=true&$expand=DM_MaterialId($expand=Material($select=NId,Name,Revision)),MaterialTypeNId";
            return Get<MaterialSpecificationDTO, MaterialSpecificationDTOResponse>(urlProfile);
        }

        public List<MaterialSpecificationDTO> GetAllMaterialSpecificationByOpId(string OpId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/MaterialSpecification?$top=10&$skip=0&$count=true&$expand=DM_MaterialId($expand=Material($select=NId,Name,Revision)),MaterialTypeNId&$filter=Operation_Id eq {OpId}";
            return Get<MaterialSpecificationDTO, MaterialSpecificationDTOResponse>(urlProfile);
        }

        public List<ProcessMachineDTO> GetAllProcessMachines(string OperationId,string AsPlannedBOP_Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/UADMGetAllProcessMachines(function=@x)?@x={{\"OperationId\":\"{OperationId}\",\"AsPlannedBOP_Id\":\"{AsPlannedBOP_Id}\"}}";
            return Get<ProcessMachineDTO, ProcessMachineDTOResponse>(urlProfile);
        }




    }
}
