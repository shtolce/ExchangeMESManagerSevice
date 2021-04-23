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
            return ExecuteCommand<MaterialDTODeleteParameter>(com, "DeleteMaterial"); ;
        }

        public MaterialDTOResponse Create(MaterialDTOCreateParameter com)
        {
            return ExecuteCommand<MaterialDTOCreateParameter>(com, "CreateMaterial"); ;
        }

        private MaterialDTOResponse ExecuteCommand<T>(T com,string commandName)
        {
            HttpWebRequest webRequest = HttpWebRequest.Create($"http://localhost/sit-svc/Application/Material/odata/{commandName}") as HttpWebRequest;
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
                    var serStatusErr = JsonConvert.DeserializeObject<MaterialDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<MaterialDTOResponse>(responseFromServer);
            return serStatus2;
        }


        public MaterialDTOResponse Update(MaterialDTOUpdateParameter com)
        {
            return ExecuteCommand<MaterialDTOUpdateParameter>(com, "UpdateMaterial");
        }

        public List<MaterialDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<MaterialDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<MaterialDTOResponse>());
            var res = content.Result;
            return res.value;

        }


        public List<MaterialDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/AppU4DM/odata/Material";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<MaterialDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/AppU4DM/odata/Material?$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }



    }
}
