using Manager.Data.Data;
using Manager.Data.DTOs.AdmSettingModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmSettingModule
{
    public class AdmSettingService : IAdmSettingService
    {
        private readonly StudentManagerEntities context;

        public AdmSettingService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<AdmSettingDTO> Create(AdmSettingDTO admSettingDTO)
        {
            try
            {
                var s = new AdmSetting
                {
                    Id = Guid.NewGuid(),

                    Name = admSettingDTO.Name,

                    IsAuto = admSettingDTO.IsAuto,

                    CreateDate = DateTime.Now,

                    CreatedBy = admSettingDTO.CreatedBy,

                    AffectedClass = admSettingDTO.AffectedClass,

                };

                context.AdmSettings.Add(s);

                await context.SaveChangesAsync();

                return admSettingDTO;
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

                var s = await context.AdmSettings.FindAsync(Id);

                if (s != null)
                {
                    context.AdmSettings.Remove(s);

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

        public async Task<List<AdmSettingDTO>> GetAll(AdmSettingDTO admSettingDTO)
        {
            try
            {
                var setting = await context.AdmSettings.ToListAsync();

                var settings = new List<AdmSettingDTO>();

                foreach (var item in setting)
                {
                    var data = new AdmSettingDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        IsAuto = admSettingDTO.IsAuto,

                        AffectedClass = admSettingDTO.AffectedClass,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    settings.Add(data);
                }

                return settings;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<AdmSettingDTO> GetById(Guid Id)
        {
            try
            {
                var setting = await context.AdmSettings.FindAsync(Id);

                return new AdmSettingDTO
                {
                    Id = setting.Id,

                    Name = setting.Name,

                    IsAuto = setting.IsAuto,

                    AffectedClass = setting.AffectedClass,

                    CreateDate = setting.CreateDate,

                    CreatedBy = setting.CreatedBy,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<AdmSettingDTO> Update(AdmSettingDTO admSettingDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.AdmSettings.FindAsync(admSettingDTO.Id);
                    {
                        s.Name = admSettingDTO.Name;

                        s.AffectedClass = admSettingDTO.AffectedClass;

                    };

                    await context.SaveChangesAsync();
                }
                return admSettingDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
