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
    public class HttpMaterialClassRepository
    {
        private AuthorizationMesService _authService;

        public HttpMaterialClassRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
        }

        public MaterialClassDTOResponse Delete(MaterialClassDTODeleteParameter com)
        {
            return ExecuteCommand<MaterialClassDTODeleteParameter>(com, "DSMaterial_DeleteMaterialClassList"); ;
        }

        public MaterialClassDTOResponse Create(MaterialClassDTOCreateParameter com)
        {
            return ExecuteCommand<MaterialClassDTOCreateParameter>(com, "DSMaterial_CreateMaterialClass"); ;
        }

        private MaterialClassDTOResponse ExecuteCommand<T>(T com,string commandName)
        {
            if (_authService.StateOAuth == null)
                return null;

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
                    var serStatusErr = JsonConvert.DeserializeObject<MaterialClassDTOResponse>(testErr);
                    return serStatusErr;

                }

            }
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<MaterialClassDTOResponse>(responseFromServer);
            return serStatus2;
        }


        public MaterialClassDTOResponse Update(MaterialClassDTOUpdateParameter com)
        {
            return ExecuteCommand<MaterialClassDTOUpdateParameter>(com, "UpdateMaterialGroup");
        }

        public List<MaterialClassDTO> Get(string urlProfile)
        {
            HttpClient client = new HttpClient();

            if (_authService.StateOAuth == null)
            {
                return new List<MaterialClassDTO>();
            }
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            client.CancelPendingRequests();
            var task = Task.Run(async () => await client.GetAsync(urlProfile));
            HttpResponseMessage output = task.Result;
            HttpContent stream = output.Content;
            var content = Task.Run(async () => await stream.ReadAsAsync<MaterialClassDTOResponse>());
            var res = content.Result;
            return res.value;

        }

        //
        public List<MaterialClassDTO> GetAll()
        {
            var urlProfile = "http://localhost/sit-svc/Application/Material/odata/DSMaterial_MaterialClass";
            return Get(urlProfile);
        }

        //Сделать фильтр через ODATA
        public List<MaterialClassDTO> GetByNId(string NId)
        {
            var urlProfile = $"http://localhost/sit-svc/Application/Material/odata/DSMaterial_MaterialClass?$filter=NId eq '{NId}'";
            return Get(urlProfile);
        }



    }
}
