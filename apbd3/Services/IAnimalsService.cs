using apbd3.Models;

namespace apbd3.Services; //logika biznesowa

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal newAnimal);
}