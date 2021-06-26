using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WepApp.Models;
using System.Net.Http;

namespace WepApp.Controllers
{
    public class Device2ResultController : Controller
    {
        // GET: Device2Result
        public ActionResult Index()
        {
            IEnumerable<Newdevice> dvobj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/Device2");

            var consumeapi = hc.GetAsync("Device2");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<Newdevice>>();
                displaydata.Wait();

                dvobj = displaydata.Result;
            }
            return View(dvobj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Newdevice insertdevice)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/Device2");

            var insertrecord = hc.PostAsJsonAsync<Newdevice>("Device2", insertdevice);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            Device2Class dvobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/");

            var consumeapi = hc.GetAsync("Device2?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Device2Class>();
                displaydata.Wait();
                dvobj = displaydata.Result;
            }
            return View(dvobj);
        }

        public ActionResult Edit(int id)
        {
            Device2Class dvobj = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/");

            var consumeapi = hc.GetAsync("Device2?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<Device2Class>();
                displaydata.Wait();
                dvobj = displaydata.Result;
            }
            return View(dvobj);
        }

        [HttpPost]
        public ActionResult Edit(Device2Class dc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/Device2");
            var insertrecord = hc.PutAsJsonAsync<Device2Class>("Device2", dc);
            insertrecord.Wait();

            var savedata = insertrecord.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Device Record Not Updated ...";
            }
            return View(dc);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44397/api/Device2");

            var delrecord = hc.DeleteAsync("Device2/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}