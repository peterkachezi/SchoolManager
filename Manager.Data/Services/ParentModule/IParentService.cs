using Manager.Data.DTOs.ParentModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.ParentModule
{
    public interface IParentService
    {
        Task<List<ParentDTO>> GetAll();
        Task<ParentDTO> GetById(Guid Id);
        Task<ParentDTO> Update(ParentDTO parentDTO);
    }
}