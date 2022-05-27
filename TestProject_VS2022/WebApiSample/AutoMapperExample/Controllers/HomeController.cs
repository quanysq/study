using AutoMapperExample.AutoMapperConfig;
using AutoMapperExample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoMapperExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private readonly Stopwatch _stopwatch = new Stopwatch();

        public ActionResult CallMapperTest1()
        {
            var userModel = new UserModel()
            {
                Age = 12,
                FirstName = "Yang",
                LastName = "JieXi",
                Sex = "Man"
            };
            var mapper = SampleMapper.Instance.MyMapper;
            var userViewModel = mapper.Map<UserViewModel>(userModel);
            return Json(userViewModel, JsonRequestBehavior.AllowGet);
        }

        private List<UserModel> userModels = new List<UserModel>()
        {
            new UserModel(){ Age = 12, FirstName="Yang", LastName="JieXi", Sex="Man"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"},
            new UserModel(){ Age = 12, FirstName="Zeng", LastName="Ben", Sex ="Womam"}
        };

        public ActionResult CallMapperTest2()
        {
            _stopwatch.Restart();
            var mapper = SampleMapper.Instance.MyMapper;
            var userViewModels = mapper.Map<List<UserViewModel>>(userModels);
            _stopwatch.Stop();

            return Json(new { data= userViewModels, time = _stopwatch.ElapsedMilliseconds }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CallMapperTest3()
        {
            _stopwatch.Restart();
            string json = JsonConvert.SerializeObject(userModels);
            var userViewModels = JsonConvert.DeserializeObject<List<UserViewModel>>(json);
            _stopwatch.Stop();
            return Json(new { data = userViewModels, time = _stopwatch.ElapsedMilliseconds }, JsonRequestBehavior.AllowGet);
        }
    }
}