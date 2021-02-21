using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASP.Net_API_MVC.Controllers
{
    public class ItemsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44366/API/")
        };

        public ActionResult Index()
        {
            IEnumerable<ItemViewModel> items = null;
            var respondTask = client.GetAsync("Items"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ItemViewModel>>();
                readTask.Wait();
                items = readTask.Result;
            }

            return View(items);
        }

        public ActionResult Detail(int id)
        {
            IEnumerable<ItemViewModel> items = null;
            var respondTask = client.GetAsync("Items"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ItemViewModel>>();
                readTask.Wait();
                items = readTask.Result;
                ItemViewModel ivm = items.Where(x => x.Id == id).FirstOrDefault();

                if (ivm == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(items.Where(x => x.Id == id).FirstOrDefault());
        }

        public ActionResult Create()
        {
            IEnumerable<Supplier> sp = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
            readTask.Wait();
            sp = readTask.Result;

            ViewBag.ItemList = new SelectList(sp.ToList(), "Id", "SupplierName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel ivm)
        {
            IEnumerable<Supplier> sp = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
            readTask.Wait();
            sp = readTask.Result;

            ViewBag.ItemList = new SelectList(sp.ToList(), "Id", "SupplierName");
            HttpResponseMessage response = client.PostAsJsonAsync("Items", ivm).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IEnumerable<Supplier> sp = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
            readTask.Wait();
            sp = readTask.Result;

            ViewBag.SupplierList = new SelectList(sp.ToList(), "Id", "SupplierName");

            IEnumerable<ItemViewModel> items = null;
            var respondTask2 = client.GetAsync("Items"); //controller
            respondTask2.Wait();
            var result2 = respondTask2.Result;

            if (result2.IsSuccessStatusCode)
            {
                var readTask2 = result2.Content.ReadAsAsync<IList<ItemViewModel>>();
                readTask2.Wait();
                items = readTask2.Result;
                ItemViewModel ivm = items.Where(x => x.Id == id).FirstOrDefault();

                if (ivm == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(items.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel ivm)
        {
            IEnumerable<Supplier> sp = null;
            var respondTask = client.GetAsync("Suppliers"); //controller
            respondTask.Wait();
            var result = respondTask.Result;
            var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
            readTask.Wait();
            sp = readTask.Result;

            ViewBag.SupplierList = new SelectList(sp.ToList(), "Id", "SupplierName");
            HttpResponseMessage putTask = client.PutAsJsonAsync("Items/" + ivm.Id, ivm).Result;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IEnumerable<ItemViewModel> items = null;
            var respondTask = client.GetAsync("Items"); //controller
            respondTask.Wait();
            var result = respondTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ItemViewModel>>();
                readTask.Wait();
                items = readTask.Result;
                ItemViewModel ivm = items.Where(x => x.Id == id).FirstOrDefault();

                if (ivm == null)
                {
                    return RedirectToAction("ErrorNotFound");
                }
            }

            return View(items.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(ItemViewModel ivm)
        {
            var delete = client.DeleteAsync("Items/" + ivm.Id.ToString());
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