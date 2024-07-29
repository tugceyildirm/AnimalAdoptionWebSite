using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessLayer.Abstract
{
    public interface IAnimalService
    {
        List<Animal> GetAnimalsList();

        void AnimalAdd(Animal animal );
        Animal GetByID(int id);
        void AnimalDelete(Animal animal);
        void AnimalUpdate(Animal animal);
        void SetActive(int id, bool isActive); 
    }
}
