using Manager.Data.DTOs.StreamModule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Data.Services.StreamModule
{
    public interface IStreamService
    {
        Task<StreamDTO> Create(StreamDTO streamDTO);
        Task<bool> Delete(Guid Id);
        Task<List<StreamDTO>> GetAll();
        Task<StreamDTO> GetById(Guid Id);
        Task<StreamDTO> Update(StreamDTO streamDTO);
    }
}