using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coding.Models;
using System.Net.Http;

namespace Coding.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IEnumerable<UsersModel> userlist = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44329/api/");

            var responseTask = hc.GetAsync("values");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var displayresults = result.Content.ReadAsAsync<IList<UsersModel>>();
                displayresults.Wait();

                userlist = displayresults.Result;
            }

            return View(userlist);
        }

        public ActionResult Getuser(int id)
        {

            IEnumerable<UsersModel> userlist = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44329/api/");

            var responseTask = hc.GetAsync("values/" + id);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var displayresults = result.Content.ReadAsAsync<IList<UsersModel>>();
                displayresults.Wait();

                userlist = displayresults.Result;
            }

            return Json(userlist, JsonRequestBehavior.AllowGet);
        }
    }
}
