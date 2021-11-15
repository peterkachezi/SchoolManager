using Manager.Data.DTOs.AdmSettingModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmSettingModule
{
    public interface IAdmSettingService
    {
        Task<AdmSettingDTO> Create(AdmSettingDTO admSettingDTO);
        Task<AdmSettingDTO> Update(AdmSettingDTO admSettingDTO);
        Task<bool> Delete(Guid Id);
        Task<List<AdmSettingDTO>> GetAll(AdmSettingDTO admSettingDTO);
        Task<AdmSettingDTO> GetById(Guid Id);
    }
}