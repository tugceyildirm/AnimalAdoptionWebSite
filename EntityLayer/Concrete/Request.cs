using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public int AnimalID { get; set; }

        public string AnimalName { get; set; }
        public string AnimalImg { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string RequestDescription { get; set; }
        public DateTime RequestDate { get; set; }
        public bool? IsApproved { get; set; }
    }
}
