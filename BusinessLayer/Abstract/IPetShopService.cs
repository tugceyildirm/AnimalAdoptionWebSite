using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPetShopService
    {
        List<PetShop> GetList();
        void PetShopAdd(PetShop petShop);
        void PetShopDelete(PetShop petShop);
        void PetShopUpdate(PetShop petShop);
        PetShop GetByID(int id);
    }
}
