using Manager.Data.DTOs.StudentModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.StudentModule
{
    public interface IStudentService
    {
        Task<StudentDTO> Create(StudentDTO studentDTO);
        Task<bool> Delete(Guid Id);
        Task<List<StudentDTO>> GetAll();
        Task<StudentDTO> GetById(Guid Id);
        Task<StudentDTO> Update(StudentDTO studentDTO);
    }
}