using Manager.Data.DTOs.DepartmentModule;
using Manager.Data.Services.DepartmentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentSercvice departmentSercvice;
        public DepartmentsController(IDepartmentSercvice departmentSercvice)
        {
            this.departmentSercvice = departmentSercvice;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create(DepartmentDTO departmentDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                departmentDTO.CreatedBy = user;

                var results = await departmentSercvice.Create(departmentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Department has been successfully created" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Department has been  not been saved" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(DepartmentDTO departmentDTO)
        {
            try
            {
                var results = await departmentSercvice.Update(departmentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "The record has been successfully updated" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "The record has been  not been updated" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> GetById(Guid Id)
        {
            try
            {
                var data = await departmentSercvice.GetById(Id);

                if (data != null)
                {
                    DepartmentDTO file = new DepartmentDTO
                    {
                        Id = data.Id,

                        Name = data.Name,

                        CreateDate = data.CreateDate,

                        CreatedBy = data.CreatedBy,

                    };

                    return Json(new { date = file }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { date = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}