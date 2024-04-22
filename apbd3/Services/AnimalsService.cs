using apbd3.Models;
using apbd3.Repositiories;
using Microsoft.AspNetCore.Mvc;

namespace apbd3.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public Animal GetAnimal(int idAnimal)
    {
        return _animalsRepository.GetAnimal(idAnimal);
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalsRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}