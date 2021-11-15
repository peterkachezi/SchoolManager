using Manager.Data.Data;
using Manager.Data.DTOs.SchoolClasseModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.SchoolClasseModule
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly StudentManagerEntities context;

        public SchoolClassService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<SchoolClassDTO> Create(SchoolClassDTO schoolClassDTO)
        {
            try
            {
                var s = new SchoolClass
                {
                    Id = Guid.NewGuid(),

                    Name = schoolClassDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedBy = schoolClassDTO.CreatedBy,
                };

                context.SchoolClasses.Add(s);

                await context.SaveChangesAsync();

                return schoolClassDTO;
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

                var s = await context.SchoolClasses.FindAsync(Id);

                if (s != null)
                {
                    context.SchoolClasses.Remove(s);

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

        public async Task<List<SchoolClassDTO>> GetAll()
        {
            try
            {
                var schoolclass = await context.SchoolClasses.ToListAsync();

                var schoolclasses = new List<SchoolClassDTO>();

                foreach (var item in schoolclass)
                {
                    var data = new SchoolClassDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    schoolclasses.Add(data);
                }

                return schoolclasses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<SchoolClassDTO> GetById(Guid Id)
        {
            try
            {
                var department = await context.SchoolClasses.FindAsync(Id);

                return new SchoolClassDTO
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


        public async Task<SchoolClassDTO> Update(SchoolClassDTO schoolClassDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())

                {
                    var s = await context.SchoolClasses.FindAsync(schoolClassDTO.Id);
                    {
                        s.Name = schoolClassDTO.Name;

                    };

                    await context.SaveChangesAsync();
                }
                return schoolClassDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}

