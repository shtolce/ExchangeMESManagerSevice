using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeMESManagerSevice.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data.Common;
using System.Data;
using System.Reflection;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System.Management;
using ExchangeMESManagerSevice.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text;
using System.IO;
using ExchangeMESManagerSevice.Models.AuthenticationModels;
using Newtonsoft.Json;
using System.Net.Http;
using ExchangeMESManagerSevice.Models.DTOModels;
using ExchangeMESManagerSevice.Models.CommandModels;
using Microsoft.Extensions.Hosting;

namespace ExchangeMESManagerSevice.Controllers
{
    public class HomeController : Controller
    {
        ExchangeSettingsContext db;
        private MESUoWService _MESUoWService;
        private SQLUoWService _SQLUoWService;
        public HomeController(ExchangeSettingsContext context , MESUoWService MESUoWService, SQLUoWService SQLUoWService)
        {
            db = context;
            _MESUoWService = MESUoWService;
            _SQLUoWService = SQLUoWService;
        }
        public IActionResult Index()
        {
            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list, list[0]);
            var test1 = _SQLUoWService.ProcessToOperationLinkSQLRepository.GetAll();

            var obj = new MaterialSpecificationDTOUpdateParameter
            {
                LogicalPosition="123"
                ,Id="92584f1b-d6a7-42d9-a251-da7a79d75df6"
                ,Quantity  =new QuantityType{UoMNId="n/a",QuantityValue=42}
            };
            //var test = _SQLUoWService.OperationSQLRepository.Create(obj);
            var test = _MESUoWService.AsPlannedBOPRepository.UpdateMaterialSpecification(obj);
            //ProcessesSQL,ASPLannedBOPSQL - не доделаны
            return View(listOptionRes);

        }

    }
}
