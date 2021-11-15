using Manager.Data.DTOs.DesignationModule;
using Manager.Data.Services.DesignationModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class DesignationsController : Controller
    {
        private readonly IDesignationService designationService;
        public DesignationsController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create(DesignationDTO designationDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                designationDTO.CreatedBy = user;

                var results = await designationService.Create(designationDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Designation has been successfully created" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Designation has been  not been saved" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(DesignationDTO designationDTO)
        {
            try
            {
                var results = await designationService.Update(designationDTO);

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
                var data = await designationService.GetById(Id);

                if (data != null)
                {
                    DesignationDTO file = new DesignationDTO
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