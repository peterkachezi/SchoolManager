using Manager.Data.Data;
using Manager.Data.DTOs.StreamModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.StreamModule
{
    public class StreamService : IStreamService
    {
        private readonly StudentManagerEntities context;

        public StreamService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<StreamDTO> Create(StreamDTO streamDTO)
        {
            try
            {
                var s = new Stream
                {
                    Id = Guid.NewGuid(),

                    Name = streamDTO.Name,

                    AssignedTo = streamDTO.AssignedTo,

                    CreateDate = DateTime.Now,

                    CreatedBy = streamDTO.CreatedBy,
                };

                context.Streams.Add(s);

                await context.SaveChangesAsync();

                return streamDTO;
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

                var s = await context.Streams.FindAsync(Id);

                if (s != null)
                {
                    context.Streams.Remove(s);

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

        public async Task<List<StreamDTO>> GetAll()
        {
            try
            {
                var stream = await context.Streams.ToListAsync();

                var streams = new List<StreamDTO>();

                foreach (var item in stream)
                {
                    var data = new StreamDTO
                    {
                        Id = item.Id,

                        Name = item.Name,

                        AssignedTo = item.AssignedTo,

                        CreateDate = item.CreateDate,

                        CreatedBy = item.CreatedBy,
                    };

                    streams.Add(data);
                }

                return streams;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public async Task<StreamDTO> GetById(Guid Id)
        {
            var stream = await context.Streams.FindAsync(Id);

            return new StreamDTO
            {
                Id = stream.Id,

                Name = stream.Name,

                AssignedTo = stream.AssignedTo,

                CreateDate = stream.CreateDate,

                CreatedBy = stream.CreatedBy,
            };

        }

        public async Task<StreamDTO> Update(StreamDTO streamDTO)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var s = await context.Streams.FindAsync(streamDTO.Id);
                    {
                        s.Name = streamDTO.Name;

                        s.AssignedTo = streamDTO.AssignedTo;
                    };

                    await context.SaveChangesAsync();
                }
                return streamDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
