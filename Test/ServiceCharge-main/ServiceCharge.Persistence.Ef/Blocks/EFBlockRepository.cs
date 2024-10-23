using Microsoft.EntityFrameworkCore;
using ServiceCharge.Entities;
using ServiceCharge.Services.Blocks.Contracts;

namespace ServiceCharge.Persistence.Ef.Blocks;

public class EFBlockRepository(EfDataContext context) : BlockRepository
{
    public void Add(Block block)
    {
        context.Set<Block>().Add(block);
    }

    public bool IsDuplicate(string name)
    {
        return context.Set<Block>()
            .Any(_ => _.Name == name);
    }

    public Block? Find(int blockId)
    {
        return context.Set<Block>().Include(_ => _.Floors)
            .FirstOrDefault(_ => _.Id == blockId);
    }

    public void Update(Block block)
    {
        context.Set<Block>().Update(block);
    }
}