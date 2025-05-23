﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Management.Domain.Services.Interfaces;

namespace Wpm.Management.Domain.ValueObjects;

public record BreedId
{
    private readonly IBreedService _breedService;
    public Guid Value { get; init; }
    public BreedId(Guid value, IBreedService breedService)
    {
        _breedService = breedService;

        ValidateBreed(value);

        Value = value;        
    }

    private void ValidateBreed(Guid value)
    {
        if (_breedService.GetBreed(value) == null)
            throw new ArgumentException("Breed is invalid", nameof(value));
    }
}
