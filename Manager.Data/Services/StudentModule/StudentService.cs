using Manager.Data.Data;
using Manager.Data.DTOs.StudentModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.Services.StudentModule
{
    public class StudentService : IStudentService
    {
        private readonly StudentManagerEntities context;
        public StudentService(StudentManagerEntities context)
        {
            this.context = context;
        }
        public async Task<StudentDTO> Create(StudentDTO studentDTO)
        {
            try
            {
                var studentId = Guid.NewGuid();

                studentDTO.Id = studentId;

                var s = new Student
                {
                    Id = studentDTO.Id,

                    FirstName = studentDTO.FirstName,

                    MiddelName = studentDTO.MiddelName,

                    LastName = studentDTO.LastName,

                    EntryClass = studentDTO.EntryClass,

                    CurrentClass = studentDTO.CurrentClass,

                    ParentId = studentDTO.ParentId,

                    KCPEMarks = studentDTO.KCPEMarks,

                    PrimarySchoolName = studentDTO.PrimarySchoolName,

                    CreateDate = DateTime.Now,

                    CreatedBy = studentDTO.CreatedBy,

                    EntryStream = studentDTO.EntryStream,

                    CurrentStream = studentDTO.CurrentStream,

                    AdmissionNumber = studentDTO.AdmissionNumber,

                };

                context.Students.Add(s);

                var p = new Parent
                {
                    Id = Guid.NewGuid(),

                    FirstName = studentDTO.ParentFirstName,

                    MiddelName = studentDTO.ParentMiddelName,

                    LastName = studentDTO.ParentLastName,

                    Email = studentDTO.Email,

                    PhoneNumber = studentDTO.PhoneNumber,

                    County = studentDTO.County,

                    HomeTown = studentDTO.HomeTown,

                    StudentId = studentDTO.Id,

                    CreateDate = DateTime.Now,

                    CreatedBy = studentDTO.CreatedBy

                };

                context.Parents.Add(p);

                await context.SaveChangesAsync();

                return studentDTO;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDTO> GetById(Guid Id)
        {
            try
            {
                var student = await context.Students.FindAsync(Id);

                return new StudentDTO
                {
                    Id = student.Id,

                    FirstName = student.FirstName,

                    MiddelName = student.MiddelName,

                    LastName = student.LastName,

                    EntryClass = student.EntryClass,

                    CurrentClass = student.CurrentClass,

                    ParentId = student.ParentId,

                    KCPEMarks = student.KCPEMarks,

                    PrimarySchoolName = student.PrimarySchoolName,

                    CreateDate = student.CreateDate,

                    CreatedBy = student.CreatedBy,

                    EntryStream = student.EntryStream,

                    CurrentStream = student.CurrentStream,

                    AdmissionNumber = student.AdmissionNumber,

                    ParentFirstName =student.Parent.FirstName,

                    ParentMiddelName = student.Parent.MiddelName,

                    ParentLastName =student.Parent.LastName,

                    PhoneNumber =student.Parent.PhoneNumber,
                        
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        public Task<StudentDTO> Update(StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
