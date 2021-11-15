using Manager.Data.DTOs.DepartmentModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.DepartmentModule
{
    public interface IDepartmentSercvice
    {
        Task<DepartmentDTO> Create(DepartmentDTO departmentDTO);
        Task<DepartmentDTO> Update(DepartmentDTO departmentDTO);
        Task<List<DepartmentDTO>> GetAll();
        Task<DepartmentDTO> GetById(Guid Id);
        Task<bool> Delete(Guid Id);
    }
}