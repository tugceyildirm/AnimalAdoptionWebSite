using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PetShop
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]

        [Display(Name = "Ürün ismi")]
        public string ProductName { get; set; }

        [Display(Name = "Ürün Açıklaması")]

        public string ProductInfo{ get; set; }
        
        
        [Display(Name = "Ürün Fotoğrafı")]
        public string ProductImage { get; set; }
     

    }
}
