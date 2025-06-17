using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain.Repositories;

public interface IManagementRepository
{
    Pet? GetById(Guid id);
    IEnumerable<Pet> GetAll();
    void Add(Pet pet);
    void Update(Pet pet);
    void Delete(Guid id);
}
