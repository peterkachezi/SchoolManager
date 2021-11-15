using Manager.Data.DTOs.SchoolClasseModule;
using Manager.Data.Services.SchoolClasseModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class StudentClassesController : Controller
    {
        private readonly ISchoolClassService  schoolClassService;
        public StudentClassesController(ISchoolClassService schoolClassService)
        {
            this.schoolClassService = schoolClassService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create(SchoolClassDTO schoolClassDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                schoolClassDTO.CreatedBy = user;

                var results = await schoolClassService.Create(schoolClassDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Class has been successfully created" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Stream has been  not been saved" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(SchoolClassDTO schoolClassDTO)
        {
            try
            {
                var results = await schoolClassService.Update(schoolClassDTO);

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
                var data = await schoolClassService.GetById(Id);

                if (data != null)
                {
                    SchoolClassDTO file = new SchoolClassDTO
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