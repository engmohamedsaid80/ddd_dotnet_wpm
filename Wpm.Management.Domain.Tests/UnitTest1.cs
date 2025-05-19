using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Implementations;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        // Arrange
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService._breeds[0].Id, breedService);

        var pet1 = new Pet(id,10, "Green", SexOfPet.Male, "PetName1", breedId);
        var pet2 = new Pet(id,15, "Yellow", SexOfPet.Female, "PetName2", breedId);

        //Act

        // Assert
        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        // Arrange
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService._breeds[0].Id, breedService);

        var pet1 = new Pet(id, 10, "Green", SexOfPet.Male, "PetName1", breedId);
        var pet2 = new Pet(id, 15, "Yellow", SexOfPet.Female, "PetName2", breedId);

        //Act

        // Assert
        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_should_be_not_equal_using_operators()
    {
        // Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService._breeds[0].Id, breedService);

        var pet1 = new Pet(id1, 10, "Green", SexOfPet.Male, "PetName1", breedId);
        var pet2 = new Pet(id2, 15, "Yellow", SexOfPet.Female, "PetName2", breedId);

        //Act

        // Assert
        Assert.True(pet1 != pet2);
    }

    [Fact]
    public void Weight_should_be_not_negative()
    {
        // Arrange
        var negativeWeight = -10.10m;
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new Weight(negativeWeight));
    }

    [Fact]
    public void Weight_should_be_equal()
    {
        // Arrange
        var weight1 = 10.10m;
        var weight2 = 10.10m;
        // Act & Assert
        Assert.True(weight1 == weight2);
    }

    [Fact]
    public void WeightRange_should_be_equal()
    {
        // Arrange
        var wr1 = new WeightRange(10.10m, 20.10m);
        var wr2 = new WeightRange(10.10m, 20.10m);
        // Act & Assert
        Assert.True(wr1 == wr2);
    }

    [Fact]
    public void Breed_should_be_valid()
    {
        // Arrange
        var breedService = new FakeBreedService();
        var id = breedService._breeds[0].Id;
        // Act
        var breedId = new BreedId(id, breedService);
        // Assert
        Assert.NotNull(breedId);
    }

    [Fact]
    public void Breed_should_not_be_valid()
    {
        // Arrange
        var breedService = new FakeBreedService();
        var id = Guid.NewGuid();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
        {
            var breedId = new BreedId(id, breedService);
        });
    }

    [Fact]
    public void WeightClass_should_be_ideal()
    {
        // Arrange
        var breedService = new FakeBreedService();

        var id = breedService._breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        var pet = new Pet(Guid.NewGuid(), 10, "Green", SexOfPet.Male, "PetName1", breedId);

        // Act
        pet.SetWeight(25, breedService);

        //Assert
        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_should_be_underweight()
    {
        // Arrange
        var breedService = new FakeBreedService();

        var id = breedService._breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        var pet = new Pet(Guid.NewGuid(), 10, "Green", SexOfPet.Male, "PetName1", breedId);

        // Act
        pet.SetWeight(15, breedService);

        //Assert
        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }

    [Fact]
    public void WeightClass_should_be_overweight()
    {
        // Arrange
        var breedService = new FakeBreedService();

        var id = breedService._breeds[0].Id;
        var breedId = new BreedId(id, breedService);

        var pet = new Pet(Guid.NewGuid(), 10, "Green", SexOfPet.Male, "PetName1", breedId);

        // Act
        pet.SetWeight(40, breedService);

        //Assert
        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }
}
