using Manager.Data.DTOs.EmployeeModule;
using Manager.Data.Services.EmployeeModule;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manager.Areas.Administrator.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService  employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Create(EmployeeDTO employeeDTO)
        {
            try
            {
                var user = User.Identity.GetUserId();

                employeeDTO.CreatedBy = user;

                var results = await employeeService.Create(employeeDTO);

                if (results != null)
                {
                    return Json(new { success = true, responseText = "Employee has been successfully created" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, responseText = "Employee has been  not been saved" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ActionResult> Update(EmployeeDTO employeeDTO)
        {
            try
            {
                var results = await employeeService.Update(employeeDTO);

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
                var data = await employeeService.GetById(Id);

                if (data != null)
                {
                    EmployeeDTO file = new EmployeeDTO
                    {
                        Id = data.Id,

                        FirstName = data.FirstName,

                        MiddleName = data.MiddleName,

                        LastName = data.LastName,

                        PhoneNumber = data.PhoneNumber,

                        Email = data.Email,

                        Department = data.Department,

                        DepartmentName = data.DepartmentName,

                        Designation = data.Designation,

                        DesignationName = data.DesignationName,

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