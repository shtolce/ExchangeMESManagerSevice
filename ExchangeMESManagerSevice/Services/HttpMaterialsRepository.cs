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

        public MaterialDTOResponse DeleteMaterial(MaterialDTODeleteParameter com)
        {
            return ExecuteCommand<MaterialDTODeleteParameter>(com, "DeleteMaterial"); ;
        }

        public MaterialDTOResponse CreateMaterial(MaterialDTOCreateParameter com)
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


        public MaterialDTOResponse UpdateMaterial(MaterialDTOUpdateParameter com)
        {
            return ExecuteCommand<MaterialDTOUpdateParameter>(com, "UpdateMaterial");
        }



        public List<MaterialDTO> getAll()
        {
            //Функция чтения материалов отрабтана тестово успешно
            HttpClient client = new HttpClient();
            var urlProfile = "http://localhost/sit-svc/Application/Material/odata/Material";

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




    }
}
