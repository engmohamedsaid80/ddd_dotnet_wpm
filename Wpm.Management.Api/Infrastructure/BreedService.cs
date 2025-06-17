using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infrastructure;

public class BreedService : IBreedService
{
    public readonly List<Breed> _breeds = new()
    {
        new Breed(Guid.Parse("6b6c5c10-e373-488a-9703-6ddf01697478"), "Labrador", new WeightRange(25, 30), new WeightRange(20, 25)),
        new Breed(Guid.Parse("a8c20bec-0857-41c4-9351-b9180acefb10"), "Beagle", new WeightRange(10, 15), new WeightRange(8, 12)),
        new Breed(Guid.Parse("18816627-8d1d-46a6-8198-07f821e86497"), "Bulldog", new WeightRange(20, 25), new WeightRange(18, 23))
    };
    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Breed is not valid", nameof(id));

        var breed = _breeds.FirstOrDefault(b => b.Id == id);

        return breed ?? throw new ArgumentException("Breed not found", nameof(id));
    }
}
