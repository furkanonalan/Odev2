using StudentDepartment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDepartment.Controllers
{
    public class RegisterController : Controller
    {
		StudentDepartmentEntities db = new StudentDepartmentEntities();
		// GET: Register

		public ActionResult SetDataInDataBase()
        {
            return View();
        }
		[HttpPost]
		public ActionResult SetDataInDataBase(CreateStuAndDep model)
		{
			CreateStuAndDep tbl = new CreateStuAndDep();
			
			tbl.StuName = model.StuName;
			tbl.DepName = model.DepName;
			db.CreateStuAndDep.Add(tbl);
			db.SaveChanges();
			return View();
		}
		public ActionResult ShowDataBaseForUser()
		{
			var item = db.CreateStuAndDep.ToList();
			return View(item);
		}
		public ActionResult Delete(int id)
		{
			var item = db.CreateStuAndDep.Where(x=>x.ID==id).First();
			db.CreateStuAndDep.Remove(item);
			db.SaveChanges();
			var item2 = db.CreateStuAndDep.ToList();
			return View("ShowDataBaseForUser",item2);
		}
		public ActionResult Edit(int id)
		{
			var item = db.CreateStuAndDep.Where(x => x.ID == id).First();
			return View();
		}
		[HttpPost]
		public ActionResult Edit(CreateStuAndDep model)
		{
			var item = db.CreateStuAndDep.Where(x => x.ID == model.ID).First();
			item.StuName = model.StuName;
			item.DepName = model.DepName;
			db.SaveChanges();
			return View();
		}
	}
}
