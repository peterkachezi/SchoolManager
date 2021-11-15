using Manager.Data.DTOs.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.EmployeeModule
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> Create(EmployeeDTO employeeDTO);
        Task<bool> Delete(Guid Id);
        Task<List<EmployeeDTO>> GetAll();
        Task<EmployeeDTO> GetById(Guid Id);
        Task<EmployeeDTO> Update(EmployeeDTO employeeDTO);
    }
}