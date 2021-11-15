using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Data.DTOs.AdmSettingModule
{
    public class AdmSettingDTO
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAuto { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string AffectedClass { get; set; }
    }
}
