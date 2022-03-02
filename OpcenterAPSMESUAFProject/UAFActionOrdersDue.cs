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
using System.Threading;

namespace OpcenterAPSMESUAFProject
{
    public partial class UAFAction : IUAFAction
    {
        private const string ServiceLayerUrlOD = @"http://localhost/sit-svc/Application/AppU4DM/odata/";

        private RestClient CreateRestClientObjectOD(string entityName)
        {
            var client = new RestClient(ServiceLayerUrlOD + entityName);
            return client;

        }

        //Получает данные об статусе ордеров с MES
        public int RunOrdersDue(ref PreactorObj preactorComObject, ref object pespComObject)
        {
            IPreactor preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            IRestResponse response;
            try
            {
                token = getAuthorization();//GetAuthorizationBearerToken(CertificatePath, CertificatePassword);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, CertificateErrorMessage);
                return 0;
            }
            //------------------------------------------------
            var client = CreateRestClientObjectOD(@"WorkOrder?$expand=FinalMaterial($expand = Material),ProductionType($select= NId),WorkOrderOperations($expand=ToBeConsumedMaterials,ToBeUsedMachines),SegregationTags, ProducedMaterialItems($expand= DM_MaterialTrackingUnit($expand = MaterialTrackingUnit($select = code)))");
            var request = CreateRestRequestObject();
            Thread.Sleep(1500);
            var responseR = client.ExecuteAsGet(request,"GET");

            //------------------------------------------------
            return 0;
        }

    }



}
