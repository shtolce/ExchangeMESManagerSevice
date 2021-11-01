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
    public class HttpEquipmentConfigurationRepository
    {
        private AuthorizationMesService _authService;

        public HttpEquipmentConfigurationRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public EquipmentConfigurationDTOResponse Delete(EquipmentConfigurationDTODeleteParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTODeleteParameter, EquipmentConfigurationDTOResponse>(com, "DeleteEquipmentConfiguration"); ;
        }
        public EquipmentConfigurationDTOResponse Create(EquipmentConfigurationDTOCreateParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTOCreateParameter, EquipmentConfigurationDTOResponse>(com, "CreateEquipmentConfiguration"); ;
        }
        public EquipmentConfigurationDTOResponse Update(EquipmentConfigurationDTOUpdateParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTOUpdateParameter, EquipmentConfigurationDTOResponse>(com, "UpdateEquipmentConfiguration");
        }

        public EquipmentGroupConfigurationDTOResponse DeleteGroup(EquipmentGroupConfigurationDTODeleteParameter com)
        {
            return ExecuteCommand<EquipmentGroupConfigurationDTODeleteParameter, EquipmentGroupConfigurationDTOResponse>(com, "DeleteEquipmentGroupConfiguration"); ;
        }
        public EquipmentGroupConfigurationDTOResponse CreateGroup(EquipmentGroupConfigurationDTOCreateParameter com)
        {
            return ExecuteCommand<EquipmentGroupConfigurationDTOCreateParameter, EquipmentGroupConfigurationDTOResponse>(com, "CreateEquipmentGroupConfiguration"); ;
        }
        public EquipmentGroupConfigurationDTOResponse UpdateGroup(EquipmentGroupConfigurationDTOUpdateParameter com)
        {
            return ExecuteCommand<EquipmentGroupConfigurationDTOUpdateParameter, EquipmentGroupConfigurationDTOResponse>(com, "UpdateEquipmentGroupConfiguration");
        }
        public EquipmentGroupConfigurationDTOResponse AssociateGroup(EquipmentGroupConfigurationDTOAssociateParameter com)
        {
            return ExecuteCommand<EquipmentGroupConfigurationDTOAssociateParameter, EquipmentGroupConfigurationDTOResponse>(com, "AssociateEquipmentConfigurationsWithEquipmentGroupConfiguration");
        }

        private D ExecuteCommand<T,D>(T com,string commandName) 
            where D:class
        {
            if (_authService.StateOAuth == null)
                return null; 
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/Equipment/odata/{commandName}") as HttpWebRequest;
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


        public List<EquipmentConfigurationDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/EquipmentConfiguration";
            return Get<EquipmentConfigurationDTO,EquipmentConfigurationDTOResponse>(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<EquipmentConfigurationDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/EquipmentConfiguration?$filter=NId eq '{NId}'";
            return Get<EquipmentConfigurationDTO, EquipmentConfigurationDTOResponse>(urlProfile);
        }


        public List<EquipmentGroupConfigurationDTO> GetAllGroup()
        {
            var urlProfile = "http://localhost/sit-svc/Application/Equipment/odata/EquipmentGroupConfiguration?$expand=EquipmentConfigurations";
            return Get<EquipmentGroupConfigurationDTO, EquipmentGroupConfigurationDTOResponse>(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<EquipmentGroupConfigurationDTO> GetGroupByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Equipment/odata/EquipmentGroupConfiguration?$expand=EquipmentConfigurations&$filter=NId eq '{NId}'";
            return Get<EquipmentGroupConfigurationDTO, EquipmentGroupConfigurationDTOResponse>(urlProfile);
        }




    }
}
