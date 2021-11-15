using Manager.Data.DTOs.StreamModule;
using Manager.Data.Services.StreamModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class StreamsController : Controller
    {
        private readonly IStreamService streamService;
        public StreamsController(IStreamService streamService)
        {
            this.streamService = streamService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create(StreamDTO streamDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                streamDTO.CreatedBy = user;

                var results = await streamService.Create(streamDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Stream has been successfully created" }, JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> Update(StreamDTO streamDTO)
        {
            try
            {
                var results = await streamService.Update(streamDTO);

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
                var data = await streamService.GetById(Id);

                if (data != null)
                {
                    StreamDTO file = new StreamDTO
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