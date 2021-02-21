using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_API_MVC.Controllers
{
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44366/API/")
        };

        // GET: Suppliers
        public ActionResult Index()
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
            }

            return View(suppliers);
        }

        public ActionResult Detail(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
                Supplier sp = suppliers.Where(x => x.Id == id).FirstOrDefault();

                if(sp == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        public ActionResult ErrorNotFound()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("Suppliers", supplier).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
                Supplier sp = suppliers.Where(x => x.Id == id).FirstOrDefault();

                if (sp == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            HttpResponseMessage putTask = client.PutAsJsonAsync("suppliers/" + supplier.Id, supplier).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<Supplier> suppliers = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                suppliers = readTask.Result;
                Supplier sp = suppliers.Where(x => x.Id == id).FirstOrDefault();

                if (sp == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(suppliers.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(Supplier supplier)
        {
            var delete = client.DeleteAsync("suppliers/" + supplier.Id.ToString());
            delete.Wait();

            var result = delete.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}