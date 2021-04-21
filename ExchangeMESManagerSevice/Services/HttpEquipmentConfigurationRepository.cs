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

        public EquipmentConfigurationDTOResponse DeleteEquipmentConfiguration(EquipmentConfigurationDTODeleteParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTODeleteParameter>(com, "DeleteEquipmentConfiguration"); ;
        }

        public EquipmentConfigurationDTOResponse CreateEquipmentConfiguration(EquipmentConfigurationDTOCreateParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTOCreateParameter>(com, "CreateEquipmentConfiguration"); ;
        }

        private EquipmentConfigurationDTOResponse ExecuteCommand<T>(T com,string commandName)
        {
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
                    var serStatusErr = JsonConvert.DeserializeObject<EquipmentConfigurationDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<EquipmentConfigurationDTOResponse>(responseFromServer);
            return serStatus2;
        }


        public EquipmentConfigurationDTOResponse UpdateEquipmentConfiguration(EquipmentConfigurationDTOUpdateParameter com)
        {
            return ExecuteCommand<EquipmentConfigurationDTOUpdateParameter>(com, "UpdateEquipmentConfiguration");
        }

        public List<EquipmentConfigurationDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<EquipmentConfigurationDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<EquipmentConfigurationDTOResponse>());
            var res = content.Result;
            return res.value;

        }


        public List<EquipmentConfigurationDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/EquipmentConfiguration";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<EquipmentConfigurationDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/EquipmentConfiguration?$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }



    }
}
