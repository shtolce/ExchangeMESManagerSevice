﻿using System;
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
        public HomeController(ExchangeSettingsContext context , MESUoWService MESUoWService)
        {
            db = context;
            _MESUoWService = MESUoWService;
        }
        public IActionResult Index()
        {
            List<string> list = WMISevice.GetSQLInstances().ToList();
            SelectList listOptionRes = new SelectList(list, list[0]);
            var test = _MESUoWService.WorkOrdersRepository.GetAll();
            var command = new WorkOrderDTOCreateParameter
            {
                NId = "gqwtt123456",
                ProductionTypeNId = "FullQuantity",
                FinalMaterialId = "0dbfd323-15ad-4aba-8835-c49700a6182a",
                Plant = "Enterprise",
                BatchId = "MB_SF_20210427_078",
                ERPOrder = "gqwtt123456",
                InitialQuantity = 3,
                PlannedTargetQuantity = null,
                Name = "er123",
                Sequence = 1,

            };
            var res = _MESUoWService.WorkOrdersRepository.CreateWorkOrder(command);

            return View(listOptionRes);

        }

    }
}
