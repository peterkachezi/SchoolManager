using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.AdmRegisterModule
{
    public class AdmRegisterDTO
    {
        public Guid Id { get; set; }
        public string AdmissionNumber { get; set; }
        public System.DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
