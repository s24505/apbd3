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
        var data = _animalsRepository.GetAnimals(orderBy);
        return data;
    }

    public Animal GetAnimal(int idAnimal)
    {
        var data = _animalsRepository.GetAnimal(idAnimal);
        return data;
    }

    public int CreateAnimal(Animal animal)
    {
        var data = _animalsRepository.CreateAnimal(animal);
        return data;
    }

    public int UpdateAnimal(Animal animal)
    {
        var data = _animalsRepository.UpdateAnimal(animal);
        return data;
    }

    public int DeleteAnimal(int idAnimal)
    {
        var data = _animalsRepository.DeleteAnimal(idAnimal);
        return data;
    }
}