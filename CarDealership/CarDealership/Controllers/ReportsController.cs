﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        
        [Route("Reports/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Reports/Sales")]
        public ActionResult Sales()
        {
            return View();
        }

        [Route("Reports/Inventory")]
        public ActionResult Inventory()
        {
            return View();
        }
    }
}