using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS_HERA_MVC.Models;
using CMS_HERA_MVC.Interfaces;
using CMS_HERA_MVC.Repository;



namespace CMS_HERA_MVC.Controllers
{
    
    public class RoleController : Controller
    {

        private readonly IRole _iRole;
    public RoleController(IRole IRole)
    {
        _iRole = IRole;
    }


    // GET: Role
    public ActionResult Index()
    {
        return View(_iRole.GetAllRole());
    }

    // GET: Role/Details
    public ActionResult Details(int? id_role)
    {
        if (id_role == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Role role = _iRole.GetRoleById(id_role);
        if (role == null)
        {
            return HttpNotFound();
        }
        return View(role);
    }

    [Authorize]
    // GET: Role/Create
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "id_role,titre_role,permissions,position_role,statut_role,date_creation")] Role role)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //role.UserId = Convert.ToInt32(Session["UserID"]);
                _iRole.AddRole(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // GET: Role/Edit
    public ActionResult Edit(int? id_role)
    {
        try
        {

            if (id_role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role roleMaster = _iRole.GetRoleById(id_role);
            if (id_role == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        catch (Exception)
        {
            throw;
        }
    }

    // POST: Role/Edit
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "id_role,titre_role,permissions,position_role,statut_role,date_creation")] Role role)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //role.UserId = Convert.ToInt32(Session["UserID"]);
                _iRole.UpdateRole(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // GET: Role/Delete
    public ActionResult Delete(int? id_role)
    {
        try
        {
            if (id_role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _iRole.GetRoleById(id_role);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // POST: Role
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id_role)
    {
        try
        {
            _iRole.DeleteRole(id_role);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            throw;
        }
    }
    //public ActionResult LoadallRoles()
    //{
    //    try
    //    {
    //        //var draw = Request.Form.GetValues("draw").FirstOrDefault();
    //        //var start = Request.Form.GetValues("start").FirstOrDefault();
    //        //var length = Request.Form.GetValues("length").FirstOrDefault();
    //        //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
    //        //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
    //        //var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
    //        //int pageSize = length != null ? Convert.ToInt32(length) : 0;
    //        //int skip = start != null ? Convert.ToInt32(start) : 0;

    //        int recordsTotal = 0;

    //        //var rolesData = _iRole.ShowAllRole(sortColumn, sortColumnDir, searchValue);
    //        //recordsTotal = rolesData.Count();
    //        //var data = rolesData.Skip(skip).Take(pageSize).ToList();

    //        //return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}
    public JsonResult CheckRoleName(string titre_role)
    {
        try
        {
            var result = _iRole.CheckRoleNameExists(titre_role);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        catch (Exception)
        {
            throw;
        }
    }


}
}
