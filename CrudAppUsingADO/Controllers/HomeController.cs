using CrudAppUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Inserted successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }



        }

        public ActionResult Edit(int Id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.UpdateEmployee(emp);
                    if (check == true)
                    {
                        TempData["UpdateMessage"] = "Data Updated successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.Id == Id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int Id, Employee emp)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            bool check = context.DeleteEmployee(Id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "Data Deleted successfully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}