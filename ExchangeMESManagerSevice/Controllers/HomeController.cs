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
        private HttpDMMaterialsRepository _DMMaterialRepo;
        private HttpUoMRepository _UoMRepository;
        private HttpMaterialClassRepository _MaterialClassRepository;
        public HomeController(ExchangeSettingsContext context, IHostedService authService, HttpMaterialsRepository materialRepo
            , HttpDMMaterialsRepository DMMaterialRepo
            , HttpUoMRepository UoMRepository
            , HttpMaterialClassRepository MaterialClassRepository
            )
        {
            db = context;
            _authService = (AuthorizationMesService)authService;
            _materialRepo = materialRepo;
            _DMMaterialRepo = DMMaterialRepo;
            _UoMRepository = UoMRepository;
            _MaterialClassRepository = MaterialClassRepository;
        }
        public IActionResult Index()
        {

            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list, list[0]);
            var test = _MaterialClassRepository.GetAll();



            var command = new MaterialClassDTOUpdateParameter
            {
                Id= "b14a924f-b8d9-40b4-b9d4-28835f987c73",
                Name = "844"
            };
            var res = _MaterialClassRepository.UpdateMaterialClass(command);


            return View(listOptionRes);

            /*

            var command = new UoMDTOCreateParameter
            {
                NId="test123"
                ,Name = "test123"
                ,UoMDimensionId = "0f54d6c8-aa00-4a20-95ff-a45602622545"//n/a
            };
            var res = _UoMRepository.CreateUoM(command);



            var command = new DMMaterialDTOCreateParameter
            {
                 MaterialId = "e9b5583c-71b5-4e76-abbe-eead97a2d379",
                 LogisticClassNId = "a0524950-636c-79f1-07f7-b6970482dd22",
                 MaterialClassId= "e838b8f1-ebd8-015f-2912-5f52fa87a588"
            };
            var res = _DMMaterialRepo.CreateMaterial(command);

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
            */
        }

    }
}
