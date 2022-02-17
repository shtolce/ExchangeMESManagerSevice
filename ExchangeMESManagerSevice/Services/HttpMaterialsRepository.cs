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
    public class HttpMaterialsRepository
    {
        private AuthorizationMesService _authService;

        public HttpMaterialsRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public MaterialDTOResponse Delete(MaterialDTODeleteParameter com)
        {
            return ExecuteCommand<MaterialDTODeleteParameter, MaterialDTOResponse>(com, "DeleteMaterial"); ;
        }

        public MaterialDTOResponse Create(MaterialDTOCreateParameter com)
        {
            return ExecuteCommand<MaterialDTOCreateParameter, MaterialDTOResponse>(com, "CreateMaterial"); ;
        }
        public MaterialDTOResponse Update(MaterialDTOUpdateParameter com)
        {
            return ExecuteCommand<MaterialDTOUpdateParameter, MaterialDTOResponse>(com, "UpdateMaterial");
        }

        public BoMDTOResponse CreateBoM(BoMDTOCreateParameter com)
        {
            return ExecuteCommand<BoMDTOCreateParameter, BoMDTOResponse>(com, "DSMaterial_CreateBoM"); ;
        }

        public BoMItemDTOResponse CreateBoMItem(BoMItemDTOCreateParameter com)
        {
            return ExecuteCommand<BoMItemDTOCreateParameter, BoMItemDTOResponse>(com, "CreateBoMItem", "AppU4DM"); ;
        }
        public BoMItemDTOResponse UpdateBoMItem(BoMItemDTOUpdateParameter com)
        {
            return ExecuteCommand<BoMItemDTOUpdateParameter, BoMItemDTOResponse>(com, "UpdateBoMItem", "AppU4DM"); ;
        }

        public BoMItemDTOResponse DeleteBoMItemList(BoMItemDTODeleteParameter com)
        {
            return ExecuteCommand<BoMItemDTODeleteParameter, BoMItemDTOResponse>(com, "DeleteBoMItemList", "AppU4DM"); ;
        }
        

        public BoMDTOResponse ChangeBoMStatus(MaterialDTOCreateParameter com)
        {
            return ExecuteCommand<MaterialDTOCreateParameter, BoMDTOResponse>(com, "DSMaterial_ChangeBoMStatus"); ;
        }




        private D ExecuteCommand<T, D>(T com, string commandName,string AppName="Material")
            where D : class
        {
            if (_authService.StateOAuth == null)
                return null;
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/{AppName}/odata/{commandName}") as HttpWebRequest;
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
                if (ex.Response == null)
                    return null;

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
            postStream.Close();

            return serStatus2;
        }

        public List<T> Get<T, D>(string urlProfile) where D : IResponse<T>
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
        public List<MaterialDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/Material";
            return Get<MaterialDTO, MaterialDTOResponse>(urlProfile); 
        }

        public List<BoMDTO> GetAllBoM()
        {
            var urlProfile = "http://localhost/sit-svc/Application/Material/odata/DSMaterial_BoM?$expand=BoMItem";
            return Get<BoMDTO, BoMDTOResponse>(urlProfile);
        }

        public List<BoMItemDTO> GetAllBoMItem()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/BoMItem?$expand=MaterialDefinition($expand=Material),BoMItemBoM,GroupType";
            return Get<BoMItemDTO, BoMItemDTOResponse>(urlProfile);
        }

        public List<BoMItemDTO> GetAllBoMItemByBoMId(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/BoMItem?$expand=MaterialDefinition($expand= Material),BoMItemBoM,GroupType&$filter=BoM_Id eq {Id}";
            return Get<BoMItemDTO, BoMItemDTOResponse>(urlProfile);
        }

        public List<BoMDTO> GetBoMByMatDefId(string Id)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Material/odata/DSMaterial_BoM?$filter=MaterialDefinition/Material_Id eq {Id}";
            return Get<BoMDTO, BoMDTOResponse>(urlProfile);
        }
        public List<BoMDTO> GetBoMByMatDefNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Material/odata/DSMaterial_BoM?$filter=MaterialDefinition/Material/NId eq '{NId}'";
            return Get<BoMDTO, BoMDTOResponse>(urlProfile);
        }

        public List<BoMDTO> GetBoMByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Material/odata/DSMaterial_BoM?$filter=NId eq '{NId}'";
            return Get<BoMDTO, BoMDTOResponse>(urlProfile);
        }

        //GET /sit-svc/Application/AppU4DM/odata/BoMItem?$expand=MaterialDefinition($expand=Material),BoMItemBoM,GroupType&$filter=BoM_Id%20eq%20a09bf207-e560-4919-9aac-7774e3eb98e5 HTTP/1.1



        //Сделать фильтр через ODATA
        public List<MaterialDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Material?$filter=NId eq '{NId}'";
            return Get<MaterialDTO, MaterialDTOResponse>(urlProfile);
        }

    }
}
