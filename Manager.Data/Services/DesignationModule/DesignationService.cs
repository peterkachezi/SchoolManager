using Manager.Data.Data;
using Manager.Data.DTOs.DesignationModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.DesignationModule
{
    public class DesignationService : IDesignationService
    {
        private readonly StudentManagerEntities context;
        public DesignationService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<DesignationDTO> Create(DesignationDTO designationDTO)
        {
            try
            {
                var s = new Designation
                {
                    Id = Guid.NewGuid(),

                    Name = designationDTO.Name,

                    CreateDate = DateTime.Now,

                    CreatedBy = designationDTO.CreatedBy,
                };

                context.Designations.Add(s);

                await context.SaveChangesAsync();

                return designationDTO;
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

                var s = await context.Designations.FindAsync(Id);

                if (s != null)
                {
                    context.Designations.Remove(s);

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
        public async Task<List<DesignationDTO>> GetAll()
        {
            var designation = await context.Designations.ToListAsync();

            var designations = new List<DesignationDTO>();

            foreach (var item in designation)
            {
                var data = new DesignationDTO
                {
                    Id = item.Id,

                    Name = item.Name,

                    CreateDate = item.CreateDate,

                    CreatedBy = item.CreatedBy,
                };

                designations.Add(data);
            }

            return designations;
        }
        public async Task<DesignationDTO> GetById(Guid Id)
        {
            var designation = await context.Designations.FindAsync(Id);

            return new DesignationDTO
            {
                Id = designation.Id,

                Name = designation.Name,

                CreateDate = designation.CreateDate,

                CreatedBy = designation.CreatedBy,
            };

        }
        public async Task<DesignationDTO> Update(DesignationDTO designationDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Designations.FindAsync(designationDTO.Id);
                    {
                        s.Name = designationDTO.Name;

                    };

                    await context.SaveChangesAsync();
                }
                return designationDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
