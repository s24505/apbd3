﻿using apbd3.Models;
using apbd3.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd3.Controllers; //infrastruktura

[Route("api/animals")] //zadania http maja byc przekierowane tutaj
[ApiController] //mowimy ze budujemy REST API, zazwyczaj zwracamy JSON
public class AnimalsController : ControllerBase
{
    private readonly IAnimalsService _animalsService;
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "name")
    {
        var animals = _animalsService.GetAnimals(orderBy); //nie chcemy tu logiki biznesowej, tylko w services
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(Animal animal)
    {
        _animalsService.UpdateAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{idAnimal:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        _animalsService.DeleteAnimal(idAnimal);
        return NoContent();
    }
}