using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Application;

public class ManagemantApplicationService(IBreedService breedService,
                                          ManagementDbContext dbContext)
{
    public async Task Handle(CreatePetCommand command)
    {
        
        var breedId = new BreedId(command.BreedId, breedService);
        var pet = new Pet(command.Id,
                          command.Age,
                          command.Color,
                          command.SexOfPet,
                          command.Name,
                          breedId);
        await dbContext.AddAsync(pet);
        await dbContext.SaveChangesAsync();
    }
}
