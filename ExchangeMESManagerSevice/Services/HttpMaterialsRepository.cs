using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeMESManagerSevice.Models.DTOModels;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Services
{
    public class HttpMaterialsRepository
    {
        private AuthorizationMesService _authService;

        public HttpMaterialsRepository(IHostedService authService)
        {
            _authService = (AuthorizationMesService)authService;
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
            
            /*
            //Функция вызова бекэнд команды CreateMaterial с параметрами
            HttpWebRequest webRequest = HttpWebRequest.Create("http://localhost/sit-svc/Application/Material/odata/CreateMaterial") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";

            var comTest = new Command<MaterialDTOParameter>()
            {
                command = new MaterialDTOParameter
                {
                    Description = "test123"
                    ,
                    UseDefault = false
                    ,
                    Name = "test123"
                    ,
                    NId = "test123"
                    ,
                    Revision = "A"
                    ,
                    TemplateNId = "matTemplate"
                    ,
                    UId = "1234"
                    ,
                    UoMNId = "cm"
                }

            };

            string parameters = JsonConvert.SerializeObject(comTest);

            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentLength = byteArray.Length;
            webRequest.Headers.Add("Authorization", "Bearer " + _authService.StateOAuth.access_token);
            Stream postStream = webRequest.GetRequestStream();
            WebResponse response = webRequest.GetResponse();
            postStream = webRequest.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            response = webRequest.GetResponse();
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            var serStatus2 = JsonConvert.DeserializeObject<MaterialDTOResponse>(responseFromServer);

    */


        }




    }
}
