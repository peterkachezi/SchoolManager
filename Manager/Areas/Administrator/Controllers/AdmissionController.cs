using Manager.Data.DTOs.StudentModule;
using Manager.Data.Services.StudentModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IStudentService studentService;
        public AdmissionController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterStudent()
        {
            return View();
        }
        public async Task<ActionResult> Create(StudentDTO studentDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                studentDTO.CreatedBy = user;

                var results = await studentService.Create(studentDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Student has been successfully registered" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Student has been  not been saved" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(StudentDTO studentDTO)
        {
            try
            {
                var results = await studentService.Update(studentDTO);

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
                var data = await studentService.GetById(Id);

                if (data != null)
                {
                    StudentDTO file = new StudentDTO
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

                        MiddelName = data.MiddelName,

                        LastName = data.LastName,

                        EntryClass = data.EntryClass,

                        CurrentClass = data.CurrentClass,

                        ParentId = data.ParentId,

                        KCPEMarks = data.KCPEMarks,

                        PrimarySchoolName = data.PrimarySchoolName,

                        CreateDate = data.CreateDate,

                        CreatedBy = data.CreatedBy,

                        EntryStream = data.EntryStream,

                        CurrentStream = data.CurrentStream,

                        AdmissionNumber = data.AdmissionNumber,

                        ParentFirstName = data.ParentFirstName,

                        ParentMiddelName = data.ParentMiddelName,

                        ParentLastName = data.ParentLastName,

                        PhoneNumber = data.PhoneNumber,
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