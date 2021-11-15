using Manager.Data.DTOs.DesignationModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.DesignationModule
{
    public interface IDesignationService
    {
        Task<DesignationDTO> Create(DesignationDTO  designationDTO);
        Task<DesignationDTO> Update(DesignationDTO designationDTO);
        Task<List<DesignationDTO>> GetAll();
        Task<DesignationDTO> GetById(Guid Id);
        Task<bool> Delete(Guid Id);
    }
}