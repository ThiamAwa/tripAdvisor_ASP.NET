using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MvcExampleM1GlGroupe2.Models;

namespace MvcExampleM1GlGroupe2.Controllers
{

    public class EmployeeController : Controller
    {
        private BdtripAdvisorContext db = new BdtripAdvisorContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(db.employee.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Employee emp)
        {
            db.employee.Add(emp);
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetbyID(int ID)
        {
            var Employee = db.employee.ToList().Find(x => x.EmployeeID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Employee emp)
        {
            Employee e = db.employee.Find(emp.EmployeeID);
            e.Age = emp.Age;
            e.Country = emp.Country;
            e.State = emp.State;
            e.Name = emp.Name;
            db.SaveChanges();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            Employee e = db.employee.Find(ID);
            db.employee.Remove(e);
            db.SaveChanges();
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}