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

    [HttpGet]
    public IEnumerable<Animal> GetAnimals()
    {
        var data = _animalsRepository.GetAnimals();
        return data;
    }

    [HttpGet]
    public Animal GetAnimal(int idAnimal)
    {
        var data = _animalsRepository.GetAnimal(idAnimal);
        return data;
    }

    [HttpPost]
    public int CreateAnimal(Animal animal)
    {
        var data = _animalsRepository.CreateAnimal(animal);
        return data;
    }

    [HttpPut]
    public int UpdateAnimal(Animal animal)
    {
        var data = _animalsRepository.UpdateAnimal(animal);
        return data;
    }

    [HttpDelete]
    public int DeleteAnimal(int idAnimal)
    {
        var data = _animalsRepository.DeleteAnimal(idAnimal);
        return data;
    }
}