using EfStoreSession6_Practice.Dtos.Stores;
using EfStoreSession6_Practice.Entities;

namespace EfStoreSession6_Practice.EFPersistance.Stores;

public class EFStoreRepository(EFDataContext context)
{
    public void Add(Store store)
    {
        context.Set<Store>().Add(store);
    }
    public List<GetAllStoresDto> GetAll()
    {
        return context.Set<Store>().Select(
            _ => new GetAllStoresDto
            {
                Id = _.Id,
                Name = _.Name
            }).ToList();
    }

    public bool DoesStoreExistById(int id)
    {
        return context.Set<Store>().Any(_=>_.Id == id);
    }
}