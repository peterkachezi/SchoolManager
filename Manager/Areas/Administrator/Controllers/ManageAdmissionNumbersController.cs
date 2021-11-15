using Manager.Data.DTOs.AdmSettingModule;
using Manager.Data.Services.AdmSettingModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class ManageAdmissionNumbersController : Controller
    {
        private readonly IAdmSettingService  admSettingService;
        public ManageAdmissionNumbersController(IAdmSettingService admSettingService)
        {
            this.admSettingService = admSettingService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create(AdmSettingDTO admSettingDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                admSettingDTO.CreatedBy = user;

                var results = await admSettingService.Create(admSettingDTO);

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
        public async Task<ActionResult> Update(AdmSettingDTO admSettingDTO)
        {
            try
            {
                var results = await admSettingService.Update(admSettingDTO);

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
                var data = await admSettingService.GetById(Id);

                if (data != null)
                {
                    AdmSettingDTO file = new AdmSettingDTO
                    {
                        Id = data.Id,

                        Name = data.Name,

                        IsAuto = data.IsAuto,

                        AffectedClass = data.AffectedClass,

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