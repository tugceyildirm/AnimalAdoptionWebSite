using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }

        [StringLength(50)]
        [Display(Name = "Hayvan Adı")]
        public string AnimalName { get; set; }


        
        public string AnimalImg  { get; set; }
      
        [Range (0,100)]
        [Display(Name = "Hayvan Yaşı")]
        public int AnimalAge { get; set; }
      
        
        [Display(Name = "Hayvan Türü")]
        public  AnimalBreed  AnimalBreed{ get; set; }
        
        [StringLength(100)]
        [Display(Name = "Hayvan Cinsi")]
        public string AnimalType { get; set; }
        
        
        [Display(Name = "Hayvan Cinsiyeti")]
        public AnimalSex AnimalSex{ get; set; }

        [Display(Name = "Hayvan Açıklaması")]
        public string AnimalDescription{ get; set; }
        public bool IsActive { get; set; }

    }
}
