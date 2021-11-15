using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.ParentModule
{
    public class ParentDTO
    {
        public System.Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public System.Guid County { get; set; }
        public Nullable<int> HomeTown { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public System.Guid StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
