using Manager.Data.Data;
using Manager.Data.DTOs.AdmRegisterModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmRegisterModule
{
    public class AdmRegisterService : IAdmRegisterService
    {
        private readonly StudentManagerEntities context;
        public AdmRegisterService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<AdmRegisterDTO> Create(AdmRegisterDTO admRegisterDTO)
        {
            try
            {
                var s = new AdmRegister
                {
                    Id = Guid.NewGuid(),

                    AdmissionNumber = admRegisterDTO.AdmissionNumber,

                    CreateDate = DateTime.Now,

                    CreatedBy = admRegisterDTO.CreatedBy,

                };

                context.AdmRegisters.Add(s);

                await context.SaveChangesAsync();

                return admRegisterDTO;
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

                var s = await context.AdmRegisters.FindAsync(Id);

                if (s != null)
                {
                    context.AdmRegisters.Remove(s);

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
        public async Task<List<AdmRegisterDTO>> GetAll(AdmRegisterDTO admRegisterDTO)
        {
            try
            {
                var register = await context.AdmRegisters.ToListAsync();

                var registers = new List<AdmRegisterDTO>();

                foreach (var item in register)
                {
                    var data = new AdmRegisterDTO
                    {
                        Id = item.Id,

                        AdmissionNumber = item.AdmissionNumber,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    registers.Add(data);
                }

                return registers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<AdmRegisterDTO> GetById(Guid Id)
        {
            try
            {
                var register = await context.AdmRegisters.FindAsync(Id);

                return new AdmRegisterDTO
                {
                    Id = register.Id,

                    AdmissionNumber = register.AdmissionNumber,

                    CreateDate = register.CreateDate,

                    CreatedBy = register.CreatedBy,
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<AdmRegisterDTO> Update(AdmRegisterDTO admRegisterDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.AdmRegisters.FindAsync(admRegisterDTO.Id);
                    {
                        s.AdmissionNumber = admRegisterDTO.AdmissionNumber;

                    };

                    await context.SaveChangesAsync();
                }
                return admRegisterDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
