using apbd3.Models;

namespace apbd3.Repositiories; //lacznie z baza

public interface IAnimalsRepository
{
    IEnumerable<Animal> FetchAnimals();
    Animal GetAnimal(int IdAnimal);
    int UpdateAnimal(Animal animal);
}