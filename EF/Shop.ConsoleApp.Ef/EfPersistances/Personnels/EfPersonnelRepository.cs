using Shop.ConsoleApp.Ef.Dtos.Personnels;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Personnels;

public class EfPersonnelRepository(EfDataContext dbContext)
{
    public void Create(Personnel personnel)
    {
        dbContext.Personnels.Add(personnel);
    }

    public List<ShowPersonnelDto> GetAllPersonnel()
    {
        return (from user in dbContext.Users
                join personnel in dbContext.Personnels
                    on user.Id equals personnel.UserId
                    into userPersonnel
                from userPersonnels in userPersonnel.DefaultIfEmpty()
                select new ShowPersonnelDto
                {
                    Id = userPersonnels.Id,
                    Name = user.Name
                }
            ).ToList();
    }

    public Personnel GetById(int personnelId)
    {
        return dbContext.Personnels.FirstOrDefault(_ => _.Id == personnelId);
    }

    public void Delete(Personnel personnel)
    {
        dbContext.Personnels.Remove(personnel);
    }
}