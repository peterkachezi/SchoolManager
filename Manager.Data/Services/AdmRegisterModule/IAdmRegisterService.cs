using Manager.Data.DTOs.AdmRegisterModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.AdmRegisterModule
{
    public interface IAdmRegisterService
    {
        Task<AdmRegisterDTO> Create(AdmRegisterDTO admRegisterDTO);
        Task<AdmRegisterDTO> Update(AdmRegisterDTO admRegisterDTO);
        Task<bool> Delete(Guid Id);
        Task<List<AdmRegisterDTO>> GetAll(AdmRegisterDTO admRegisterDTO);
        Task<AdmRegisterDTO> GetById(Guid Id);
    }
}