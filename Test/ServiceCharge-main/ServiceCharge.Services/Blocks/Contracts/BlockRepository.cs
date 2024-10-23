using ServiceCharge.Entities;

namespace ServiceCharge.Services.Blocks.Contracts;

public interface BlockRepository
{
    void Add(Block block);
    bool IsDuplicate(string name);
    Block? Find(int blockId);
    void Update(Block block);
}