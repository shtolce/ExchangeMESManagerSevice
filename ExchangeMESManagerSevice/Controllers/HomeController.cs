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
        private AuthorizationMesService _authService;
        private HttpMaterialsRepository _materialRepo;
        public HomeController(ExchangeSettingsContext context, IHostedService authService, HttpMaterialsRepository materialRepo)
        {
            db = context;
            _authService = (AuthorizationMesService)authService;
            _materialRepo = materialRepo;
        }
        public IActionResult Index()
        {

            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list, list[0]);
            //var test = _materialRepo.getAll();
            var command = new MaterialDTOCreateParameter
            {
                Description = "test21234",
                UseDefault = false,
                Name = "test12234",
                NId = "test12324",
                Revision = "A",
                TemplateNId = null,
                UId = "123424",
                UoMNId = "cm"
            };
            var res = _materialRepo.CreateMaterial(command);

            var commandDel = new MaterialDTOUpdateParameter
            {
                Id = "756ac014-ad22-4e45-9322-fc6a850e8064"
                , Description =" 9123123123"
                , Name = "91231231"
                , UoMNId ="%"

            };

            res = _materialRepo.UpdateMaterial(commandDel);

            return View(listOptionRes);
        }

    }
}
