using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.StreamModule
{
    public class StreamDTO
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.Guid AssignedTo { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
