using ServiceCharge.Entities;
using ServiceCharge.Services.Blocks.Contracts;

namespace ServiceCharge.Persistence.Ef.Blocks;

public class EFBlockRepository(EfDataContext context) : BlockRepository
{
    public void Add(Block block)
    {
        context.Set<Block>().Add(block);
        context.SaveChanges();
    }
}