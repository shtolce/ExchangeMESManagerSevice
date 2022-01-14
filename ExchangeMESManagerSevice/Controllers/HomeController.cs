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
using MSSQLClasses;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult Index()
        {
            List<string> list = SqlLocator.GetServers().ToList();
            //WMISevice.GetSQLInstances().ToList();

            ExchangeSettings settingsPrev = db.Settings.FirstOrDefault();
            if (settingsPrev != null)
            {
                ViewData["login"] = settingsPrev.User;
                ViewData["password"] = settingsPrev.Password;
                ViewData["sqlInstance"] = settingsPrev.SQLServerInstance;

            }

            SelectList listOptionRes = new SelectList(list, list.FirstOrDefault(x=>x== settingsPrev.SQLServerInstance));
            return View(listOptionRes);

        }
        [HttpPost]
        public async Task<IActionResult> Index(string login,string password, string sqlInstance)
        {
            List<string> list = SqlLocator.GetServers().ToList();
            //WMISevice.GetSQLInstances().ToList();
            ExchangeSettings settingsPrev = db.Settings.FirstOrDefault();

            SelectList listOptionRes = new SelectList(list, list.FirstOrDefault(x => x == settingsPrev.SQLServerInstance));
            ExchangeSettings settings = new ExchangeSettings
            {
                Password = password,
                SQLServerInstance = sqlInstance,
                User =login
            };

            if (settingsPrev != null)
            {
                settingsPrev.User = login;
                settingsPrev.Password = password;
                settingsPrev.SQLServerInstance = sqlInstance;
                db.Settings.Update(settingsPrev);

            }
            else
                db.Settings.Add(settings);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");

        }

    }
}
