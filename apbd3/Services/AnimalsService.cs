using apbd3.Models;
using apbd3.Repositiories;

namespace apbd3.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        //pobieramy cos z bazy
        var data = _animalsRepository.FetchAnimals();
        //robimy cos z danymi
        return data;//zwracamy cos
    }

    public int CreateAnimal(Animal newAnimal)
    {
        //dodajemy studenta 
        return 1;
    }
}