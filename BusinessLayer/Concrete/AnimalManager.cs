using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnimalManager : IAnimalService
    {
       IAnimalDal _animalDal;

        public AnimalManager(IAnimalDal animalDal)
        {
            _animalDal = animalDal;
        } 
        public void AnimalAdd(Animal animal)
        {
            _animalDal.Insert (animal);
        }
        public void AnimalDelete(Animal animal)
        {
            _animalDal.Delete(animal);
        }
        public void AnimalUpdate(Animal animal)
        {
            _animalDal.Update(animal);
        }
        public List<Animal> GetAnimalsList()
        {

            return _animalDal.List(); 
        }
    
          public Animal GetByID(int id)
        {
            return _animalDal.Get(x => x.AnimalID == id);
        }

        public void SetActive(int id, bool isActive)
        {
            var animal = GetByID(id);
            if (animal != null)
            {
                animal.IsActive = isActive;
                AnimalUpdate(animal);
            }

        }
        public List<Animal> GetActiveAnimals()
        {
            return _animalDal.List(a => a.IsActive); // Sadece aktif olanları getir
        }

    }
}
