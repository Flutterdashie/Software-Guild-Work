﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        
        [Route("Sales/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Sales/Purchase/{id}")]
        public ActionResult Purchase(int id)
        {
            return View(id);
        }
    }
}