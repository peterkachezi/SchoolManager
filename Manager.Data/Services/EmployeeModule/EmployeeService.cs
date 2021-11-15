using Manager.Data.Data;
using Manager.Data.DTOs.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.EmployeeModule
{
    public class EmployeeService : IEmployeeService
    {
        private readonly StudentManagerEntities context;

        public EmployeeService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<EmployeeDTO> Create(EmployeeDTO employeeDTO)
        {
            try
            {
                var s = new Employee
                {
                    Id = Guid.NewGuid(),

                    FirstName = employeeDTO.FirstName,

                    MiddleName = employeeDTO.MiddleName,

                    LastName = employeeDTO.LastName,

                    PhoneNumber = employeeDTO.PhoneNumber,

                    Email = employeeDTO.Email,

                    Department = employeeDTO.Department,

                    Designation = employeeDTO.Designation,

                    CreateDate = DateTime.Now,

                    CreatedBy = employeeDTO.CreatedBy,

                };

                context.Employees.Add(s);

                await context.SaveChangesAsync();

                return employeeDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                bool result = false;

                var s = await context.Employees.FindAsync(Id);

                if (s != null)
                {
                    context.Employees.Remove(s);

                    await context.SaveChangesAsync();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            try
            {
                var employee = await context.Employees.ToListAsync();

                var employees = new List<EmployeeDTO>();

                foreach (var item in employee)
                {
                    var data = new EmployeeDTO
                    {
                        Id = item.Id,

                        FirstName = item.FirstName,

                        MiddleName = item.MiddleName,

                        LastName = item.LastName,

                        PhoneNumber = item.PhoneNumber,

                        Email = item.Email,

                        Department = item.Department,

                        Designation = item.Designation,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    employees.Add(data);
                }

                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<EmployeeDTO> GetById(Guid Id)
        {
            try
            {
                var employee = await context.Employees.FindAsync(Id);

                return new EmployeeDTO
                {
                    Id = employee.Id,

                    FirstName = employee.FirstName,

                    MiddleName = employee.MiddleName,

                    LastName = employee.LastName,

                    PhoneNumber = employee.PhoneNumber,

                    Email = employee.Email,

                    Department = employee.Department,

                    //DepartmentName = employee.Departments.Name,

                    Designation = employee.Designation,

                    //DesignationName = employee.Designations.Name,

                    CreateDate = employee.CreateDate,

                    CreatedBy = employee.CreatedBy,
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO employeeDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Employees.FindAsync(employeeDTO.Id);
                    {

                        s.FirstName = employeeDTO.FirstName;

                        s.MiddleName = employeeDTO.MiddleName;

                        s.LastName = employeeDTO.LastName;

                        s.PhoneNumber = employeeDTO.PhoneNumber;

                        s.Email = employeeDTO.Email;

                        s.Department = employeeDTO.Department;

                        s.Designation = employeeDTO.Designation;

                    };

                    await context.SaveChangesAsync();

                    return employeeDTO;
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
