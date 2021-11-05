using System;
using System.Runtime.InteropServices;
using Preactor;
using Preactor.Interop.PreactorObject;
using System.Collections.Generic;
using System.Net;
//using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Protocols.WSTrust;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;

namespace OpcenterAPSMESUAFProject
{
    [Guid("55b16622-5d65-4f09-bda0-7f02ce3f370c")]
    [ComVisible(true)]
    public interface IUAFAction
    {
        int Run(ref PreactorObj preactorComObject, ref object pespComObject);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("ca8cfb7a-743c-4f3c-b966-be9eb8411e9f")]
    public class UAFAction : IUAFAction
    {
        private IPreactor preactor;
        private string token;

        #region Input command and parameter name
        private const string InputParameterName = "APSOrderOperations";
        private const string CommandName = "SetInScheduled";
        #endregion

        #region Customer specific information
        // Asterisks indicate where user inputted data is to go
        private const string CertificateIssuer = "shtolce";
        private const string CertificatePassword = "shtolce11021980";
        private const string CertificatePath = @"";
        private const string ServiceLayerUrl = @"http://localhost/sit-svc/Application/AppU4DM/odata/";
        #endregion

        #region Operation status information messages and user infromation messages
        private const string ResultMessageHeader = "Result : SetInScheduled";
        private const string ResultSuccessMessage = "Successful!";
        private const string CertificateErrorMessage = "Problem with Certificate";
        private const string ErrorMessage = "Request url, command or message is Incorrect";
        private const string ReadingValuesErrorMessage = "Problem with reading values from preactor DB";
        private const string FailureConnectWebserviceErrorMessage = "Failure to connect web service";
        #endregion



        public int Run(ref PreactorObj preactorComObject, ref object pespComObject)
        {
            IPreactor preactor = PreactorFactory.CreatePreactorObject(preactorComObject);

            // TODO : Your code here
            SetInScheduled(ref preactorComObject,ref pespComObject);
            return 0;
        }

        /// <summary>
        ///     Create Rest client Object using Service Layer Url and Command Name - SetInScheduled
        /// </summary>
        /// <returns>Rest Client Object</returns>
        private RestClient CreateRestClientObject()
        {
            var client = new RestClient(ServiceLayerUrl + CommandName);
            return client;
        }

        /// <summary>
        ///     Create Rest request method Object including header parameters cache-control,content-type and authorization
        /// </summary>
        /// <returns>Rest Request method object</returns>
        private RestRequest CreateRestRequestObject()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "Bearer " + token);
            return request;
        }

        /// <summary>
        ///     Implementing SetInScheduled
        /// </summary>
        /// <param name="preactorComObject">Preactor Object</param>
        /// <param name="pespComObject">Pesp Object</param>
        /// <returns>Result Message</returns>
        public string SetInScheduled(ref PreactorObj preactorComObject, ref object pespComObject)
        {
            List<ScheduledOperation> operations;
            preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            IRestResponse response;

            try
            {
                // Use method GetAuthorizationBearerToken to retrive token if Certificate stored in specific path protected with password
                // Else if Cetrficate is installed on local machine - use method GetAuthorizationBearerToken(CertificateIssuer)
                token = getAuthorization();//GetAuthorizationBearerToken(CertificatePath, CertificatePassword);
                //token = GetAuthorizationBearerToken(CertificatePath, CertificatePassword);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, CertificateErrorMessage);
                return CertificateErrorMessage + " " + e.Message;
            }
            try
            {
                operations = GetScheduledOperations();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, ReadingValuesErrorMessage);
                return ReadingValuesErrorMessage + " " + e.Message;
            }
            try
            {
                response = CallSetInScheduled(operations);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, FailureConnectWebserviceErrorMessage);
                return FailureConnectWebserviceErrorMessage + " " + e.Message;
            }
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(response.StatusDescription, ErrorMessage);
                return ErrorMessage + " " + response.StatusDescription;
            }
            MessageBox.Show(ResultSuccessMessage, ResultMessageHeader);
            return ResultMessageHeader + " " + ResultSuccessMessage;
        }


        #region Supporting methods to accomplish SetInScheduled
        /// <summary>
        ///     Convert list of Scheduled Operations into web service request parameters and execute it
        /// </summary>
        /// <param name="list">List of Scheduled Operations </param>
        /// <returns>Result - success or error message</returns>
        private IRestResponse CallSetInScheduled(List<ScheduledOperation> list)
        {
            var inputParameterValue = new ApsOrderOperations
            {
                Values = new List<ApsOrderOperation>()
            };

            foreach (var scheduledOperation in list)
            {
                var apsOrderOperation = new ApsOrderOperation
                {
                    AssignedResourceNId = scheduledOperation.PreferredMachine,
                    EstimatedEndTime = scheduledOperation.EstimatedEndTime,
                    EstimatedStartTime = scheduledOperation.EstimatedStartTime,
                    NId = scheduledOperation.NId
                };
                inputParameterValue.Values.Add(apsOrderOperation);
            }

            // Convert list of ScheduledOperations into required JSON string
            var inputParameterValueString = JsonConvert.SerializeObject(inputParameterValue);
            var parameter = "{\"command\": {\"" + InputParameterName + "\": " + inputParameterValueString + "}}";
            // Create request object
            var client = CreateRestClientObject();
            var request = CreateRestRequestObject();
            request.AddParameter("application/json", parameter, ParameterType.RequestBody);
            // Call web service
            var response = client.Execute(request);
            return response;
        }
        #endregion
        #region Supporting methods to accomplish SetInScheduled

        /// <summary>
        ///     Read data from Preactor and store in scheduled operations object
        /// </summary>
        /// <returns>List of Scheduled Operation</returns>
        private List<ScheduledOperation> GetScheduledOperations()
        {
            var soList = new List<ScheduledOperation>();
            var ordersFormat = preactor.GetFormatNumber("Orders");

            var operationExternalIdNumber = preactor.GetFieldNumber(ordersFormat, "Operation External Id");
            var resourceNumber = preactor.GetFieldNumber(ordersFormat, "Resource External Id");
            var startTimeNumber = preactor.GetFieldNumber(ordersFormat, "Start Time");
            var endTimeNumber = preactor.GetFieldNumber(ordersFormat, "End Time");
            // Add more parameters if required...

            var recordCount = preactor.RecordCount(ordersFormat);

            for (var record = 1; record <= recordCount; record++)
            {
                var scheduledOperation = new ScheduledOperation
                {
                    // Read data into ScheduledOperation properties
                    NId = preactor.ReadFieldString(ordersFormat, operationExternalIdNumber, record),
                    PreferredMachine = preactor.ReadFieldString(ordersFormat, resourceNumber, record),
                    EstimatedStartTime = preactor.ReadFieldDateTime(ordersFormat, startTimeNumber, record),
                    EstimatedEndTime = preactor.ReadFieldDateTime(ordersFormat, endTimeNumber, record)
                };

                soList.Add(scheduledOperation);
            }

            return soList;
        }
        #endregion

        #region Retrieve authorization bearer token from certificate stored on machine protected with password

        /// <summary>
        ///     Method to fetch authorization bearer token from certificate stored in specific Path, protected with password
        /// </summary>
        /// <param name="certificatePath">Certificate location</param>
        /// <param name="certificatePassword">Certificate password</param>
        /// <returns> Authorization bearer string token</returns>
        private string GetAuthorizationBearerToken(string certificatePath, string certificatePassword)
        {
            var bstrPsw = Marshal.StringToBSTR(certificatePassword);
            X509Certificate2 certificate = new X509Certificate2(certificatePath, Marshal.PtrToStringBSTR(bstrPsw));
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            //Create x.509 signed token
            var now = DateTime.UtcNow;

            // Certificate has now been loaded
            var x509SigningCredentials = new X509SigningCredentials(certificate);

            // Place holder for all the attributes related to the issued token
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                // Represents a claims-based identity
                Subject = new ClaimsIdentity(
                new[]
                    {
                    new Claim(ClaimTypes.Name, certificate.Issuer),
                    new Claim(ClaimTypes.Thumbprint, certificate.Thumbprint),
                    new Claim("urn:realm", "x.509")
                    }),
                //TokenIssuerName = "urn:unifiedoauth",
                //AppliesToAddress = "urn:unified",
                //Lifetime = new Lifetime(now.AddMinutes(-5), now.AddMinutes(150)),
                SigningCredentials = x509SigningCredentials
            };

            // creates a JwtSecurityToken based on values found in the SecurityTokenDescriptor
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            token = tokenHandler.WriteToken(securityToken);
            return token;
        }
        #endregion

        private string getAuthorization()
        {
            //Web Request OAuth2 перенести в библиотеку сервиса
            string grant_type = "password";
            string username = @"shtolce";
            string password = "shtolce11021980";

            HttpWebRequest webRequest = HttpWebRequest.Create("http://localhost/sit-auth/OAuth/Token") as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            string parameters =
                  "scope=global"
                + "&client_id=" + "RaytecIntegration"
                + "&client_secret=" + password
                + "&grant_type=" + grant_type
                + "&username=" + username
                + "&password=" + password;

            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            webRequest.ContentLength = byteArray.Length;
            Stream postStream = webRequest.GetRequestStream();
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            WebResponse response = webRequest.GetResponse();
            postStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(postStream);
            string responseFromServer = reader.ReadToEnd();
            OAuthResponseModel serStatus = JsonConvert.DeserializeObject<OAuthResponseModel>(responseFromServer);
            return serStatus.access_token;
        }

    }
    public class OAuthResponseModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expiresSec
        {
            get { return expires_in; }
            set { }
        }
        public int expires_in;



    }
    //  ApsOrderOperation and ApsOrderOperations classes are used to create input paramters passed along with service url and command
    public class ApsOrderOperation
    {
        public string AssignedResourceNId { get; set; }
        public DateTimeOffset? EstimatedEndTime { get; set; }
        public DateTimeOffset? EstimatedStartTime { get; set; }
        public string NId { get; set; }
    }

    public class ApsOrderOperations
    {
        public List<ApsOrderOperation> Values { get; set; }
    }

    /// <summary>
    ///     ScheduledOperation Class is used to store data from Preactor
    /// </summary>
    public class ScheduledOperation
    {
        public DateTime EstimatedEndTime;
        public DateTime EstimatedStartTime;
        public string NId;

        public string PreferredMachine;
        // Include more parameters if required 

        public ScheduledOperation()
        {
            NId = "";
            EstimatedEndTime = EstimatedStartTime = Convert.ToDateTime("1970-01-01");
            PreferredMachine = "";
        }

        public ScheduledOperation(string nId, DateTime est, DateTime eet, string pMachine)
        {
            NId = nId;
            EstimatedStartTime = est;
            EstimatedEndTime = eet;
            PreferredMachine = pMachine;
        }
    }



}
