using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PetShopManager :IPetShopService
    {
        IPetShopDal _petShopDal;

        public PetShopManager(IPetShopDal petShopDal)
        {
            _petShopDal = petShopDal;
        }

        public PetShop GetByID(int id)
        {
            return _petShopDal.Get(x => x.ProductID == id);
        }

        public List<PetShop> GetList()
        {
            return _petShopDal.List();
        }

        public void PetShopAdd(PetShop petShop)
        {
            _petShopDal.Insert(petShop);
        }

        public void PetShopDelete(PetShop petShop)
        {
           _petShopDal.Delete(petShop);
        }

        public void PetShopUpdate(PetShop petShop)
        {
            _petShopDal.Update(petShop);
        }
    }
    
}
