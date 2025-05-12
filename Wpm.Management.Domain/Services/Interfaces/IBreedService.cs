using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain.Services.Interfaces;

public interface IBreedService
{
    Breed? GetBreed(Guid id);
}
