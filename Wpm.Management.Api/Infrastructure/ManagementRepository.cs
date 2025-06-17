using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Repositories;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementRepository : IManagementRepository
{
    public void Add(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetAll()
    {
        throw new NotImplementedException();
    }

    public Pet? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Pet pet)
    {
        throw new NotImplementedException();
    }
}
