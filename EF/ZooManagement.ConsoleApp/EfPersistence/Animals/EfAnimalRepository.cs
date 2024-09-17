using ZooManagement.ConsoleApp.Dtos.Animals;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.Animals;

public class EfAnimalRepository(EfDataContext dbContext)
{
    public void Create(Animal newAnimal)
    {
        dbContext.Animals.Add(newAnimal);
    }

    public bool Exists(string newAnimalTitle)
    {
        return dbContext.Animals.Any(a => a.Title == newAnimalTitle);
    }

    public List<ShowAnimalDto> GetAll()
    {
        return dbContext.Animals.Select(_ => new ShowAnimalDto
        {
            Id = _.Id,
            Title = _.Title,
        }).ToList();
    }

    public Animal? GetById(int animalId)
    {
        return dbContext.Animals.FirstOrDefault(_ => _.Id == animalId);
    }

    public void Delete(Animal animal)
    {
        dbContext.Animals.Remove(animal);
    }
}