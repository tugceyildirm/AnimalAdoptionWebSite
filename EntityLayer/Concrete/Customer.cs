using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer

    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        [StringLength (10)]
         public string UserPassword { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }
         
    }
}
