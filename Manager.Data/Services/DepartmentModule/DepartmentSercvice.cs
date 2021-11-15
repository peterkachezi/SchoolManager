using Manager.Data.Data;
using Manager.Data.DTOs.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.DepartmentModule
{
    public class DepartmentSercvice : IDepartmentSercvice
    {
        private readonly StudentManagerEntities context;

        public DepartmentSercvice(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<DepartmentDTO> Create(DepartmentDTO departmentDTO)
        {
            try
            {
                var s = new Department
                {
                    Id = Guid.NewGuid(),

                    Name = departmentDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedBy = departmentDTO.CreatedBy,
                };

                context.Departments.Add(s);

                await context.SaveChangesAsync();

                return departmentDTO;
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

                var s = await context.Departments.FindAsync(Id);

                if (s != null)
                {
                    context.Departments.Remove(s);

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

        public async Task<List<DepartmentDTO>> GetAll()
        {
            try
            {
                var department = await context.Departments.ToListAsync();

                var departments = new List<DepartmentDTO>();

                foreach (var item in department)
                {
                    var data = new DepartmentDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    departments.Add(data);
                }

                return departments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<DepartmentDTO> GetById(Guid Id)
        {
            try
            {
                var department = await context.Departments.FindAsync(Id);

                return new DepartmentDTO
                {
                    Id = department.Id,

                    Name = department.Name,

                    CreateDate = department.CreateDate,

                    CreatedBy = department.CreatedBy,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<DepartmentDTO> Update(DepartmentDTO departmentDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Departments.FindAsync(departmentDTO.Id);

                    s.Name = departmentDTO.Name;

                    transaction.Commit();

                }
                await context.SaveChangesAsync();

                return departmentDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
