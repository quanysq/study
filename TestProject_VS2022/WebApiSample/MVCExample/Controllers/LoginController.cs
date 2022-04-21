using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExample.BLL.IService;
using MVCExample.BLL.Service;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class LoginController : Controller
    {
        private IAdminUserService _adminUserService;
        private IHTFP14Service _HTFP14Service;
        /*public LoginController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }*/
        public LoginController(IHTFP14Service HTFP14Service)
        {
            _HTFP14Service = HTFP14Service;
        }
        // GET: Login
        public ActionResult Index()
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var HTFP14 = new HTFP14() { COMPHT14 = "001" };
                _HTFP14Service.ValidateLogin(HTFP14);
            }
            return View();
        
        }
    }
}