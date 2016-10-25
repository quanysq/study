using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProfilerDemo.DAL;
using StackExchange.Profiling;
using MiniProfilerDemo.Models;

namespace MiniProfilerDemo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
          //using (EFDbContext db = new EFDbContext())
          //{
          //  var m = db.Products.ToList();
          //  return View(m);
          //}
          using (EFDbContext db = new EFDbContext())
          {
            var profiler = MiniProfiler.Current;
            List<Product> m;
            using (profiler.Step("获取Product列表"))
            {
              m = db.Products.ToList();
            }
            return View(m);
          }
        }
	}
}