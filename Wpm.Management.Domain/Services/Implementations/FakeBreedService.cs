using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Services.Implementations;

public class FakeBreedService : IBreedService
{
    public readonly List<Breed> _breeds = new()
    {
        new Breed(Guid.NewGuid(), "Labrador", new WeightRange(25, 30), new WeightRange(20, 25)),
        new Breed(Guid.NewGuid(), "Beagle", new WeightRange(10, 15), new WeightRange(8, 12)),
        new Breed(Guid.NewGuid(), "Bulldog", new WeightRange(20, 25), new WeightRange(18, 23))
    };
    public Breed? GetBreed(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Breed is not valid", nameof(id));

        var breed = _breeds.FirstOrDefault(b => b.Id == id);

        return breed ?? throw new ArgumentException("Breed not found", nameof(id));
    }
}
