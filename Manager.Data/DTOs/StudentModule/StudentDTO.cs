using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.StudentModule
{
    public class StudentDTO
    {
        public System.Guid Id { get; set; }

        public System.Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string EntryClass { get; set; }
        public string CurrentClass { get; set; }
        public System.Guid ParentId { get; set; }
        public Nullable<int> KCPEMarks { get; set; }
        public string PrimarySchoolName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public System.Guid EntryStream { get; set; }
        public System.Guid CurrentStream { get; set; }
        public string AdmissionNumber { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentMiddelName { get; set; }
        public string ParentLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public System.Guid County { get; set; }
        public int? HomeTown { get; set; }

    }
}
