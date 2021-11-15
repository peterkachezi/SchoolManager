using Manager.Data.DTOs.SchoolClasseModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.SchoolClasseModule
{
    public interface ISchoolClassService
    {
        Task<SchoolClassDTO> Create(SchoolClassDTO schoolClassDTO);
        Task<SchoolClassDTO> Update(SchoolClassDTO schoolClassDTO);
        Task<bool> Delete(Guid Id);
        Task<List<SchoolClassDTO>> GetAll();
        Task<SchoolClassDTO> GetById(Guid Id);
    }
}