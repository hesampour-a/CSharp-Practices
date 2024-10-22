using ServiceCharge.Entities;

namespace ServiceCharge.Services.Blocks.Contracts;

public interface BlockRepository
{
    void Add(Block block);
}