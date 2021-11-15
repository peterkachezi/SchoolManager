using Manager.Data.Data;
using Manager.Data.DTOs.ParentModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.ParentModule
{
    public class ParentService : IParentService
    {
        private readonly StudentManagerEntities context;
        public ParentService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<List<ParentDTO>> GetAll()
        {
            try
            {
                var parent = await context.Parents.ToListAsync();

                var parents = new List<ParentDTO>();

                foreach (var item in parent)
                {
                    var data = new ParentDTO()
                    {
                        Id = item.Id,

                        FirstName = item.FirstName,

                        MiddelName = item.MiddelName,

                        LastName = item.LastName,

                        Email = item.Email,

                        PhoneNumber = item.PhoneNumber,

                        County = item.County,

                        HomeTown = item.HomeTown,

                        StudentId = item.StudentId,

                        StudentName = item.Student.FirstName + " " + item.Student.LastName,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,

                    };

                    parents.Add(data);
                }

                return parents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ParentDTO> GetById(Guid Id)
        {
            try
            {
                var parent = await context.Parents.FindAsync(Id);

                return new ParentDTO()
                {
                    Id = parent.Id,

                    FirstName = parent.FirstName,

                    MiddelName = parent.MiddelName,

                    LastName = parent.LastName,

                    Email = parent.Email,

                    PhoneNumber = parent.PhoneNumber,

                    County = parent.County,

                    HomeTown = parent.HomeTown,

                    StudentId = parent.StudentId,

                    StudentName = parent.Student.FirstName + " " + parent.Student.LastName,

                    CreateDate = parent.CreateDate,

                    CreatedBy = parent.CreatedBy,

                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<ParentDTO> Update(ParentDTO parentDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var parent = await context.Parents.FindAsync(parentDTO.Id);
                                     
                    parent.FirstName = parent.FirstName;

                    parent.MiddelName = parent.MiddelName;

                    parent.LastName = parent.LastName;

                    parent.Email = parent.Email;

                    parent.PhoneNumber = parent.PhoneNumber;

                    parent.County = parent.County;

                    parent.HomeTown = parent.HomeTown;

                    transaction.Commit();
                }
                
                await context.SaveChangesAsync();

                return parentDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
