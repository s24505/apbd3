using System.ComponentModel;
using apbd3.Models;

namespace apbd3.Repositiories; //lacznie z baza

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(String orderBy);
    Animal GetAnimal(int idAnimal);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}