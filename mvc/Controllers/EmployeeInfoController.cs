using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers
{
    public class EmployeeInfoController : Controller
    {

        // GET: EmployeeViewController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeViewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeViewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeViewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeViewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeViewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
