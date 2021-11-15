using Manager.Data.DTOs.ParentModule;
using Manager.Data.Services.ParentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ParentsController : Controller
    {
        private readonly IParentService parentService;
        public ParentsController(IParentService parentService)
        {
            this.parentService = parentService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Update(ParentDTO parentDTO)
        {
            try
            {
                var results = await parentService.Update(parentDTO);

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
                var data = await parentService.GetById(Id);

                if (data != null)
                {
                    ParentDTO file = new ParentDTO
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

                        MiddelName = data.MiddelName,

                        LastName = data.LastName,

                        Email = data.Email,

                        PhoneNumber = data.PhoneNumber,

                        County = data.County,

                        HomeTown = data.HomeTown,

                        StudentId = data.StudentId,

                        StudentName = data.StudentName,

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