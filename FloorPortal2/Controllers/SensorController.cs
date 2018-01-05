using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FloorPortal2.Models;
using PagedList;

namespace FloorPortal2.Controllers
{
    public class SensorController : Controller
    {       
        // GET: Sensor
        [Route("~/Sensor")]
        [Route("~/Sensor/index")]
        [Route("~/Sensor/page{page}")]
        public ActionResult Index(int? page)
        {
            var db = new SensorDbContext();

            // pagedList の使い方
            // http://seven1st.com/archives/89
            int pageNumber = page ?? 1;
            if (pageNumber < 1) pageNumber = 1;
            int pageSize = 20;

            var SensorTagPages = db.SensorTags
                                   .OrderBy(s => s.EventProcessedTime)
                                   .ToPagedList(pageNumber, pageSize);

            return View(SensorTagPages);
        }

    }
}