namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        // Arrange
        var id = Guid.NewGuid();
        var pet1 = new Pet(id,10, "Green", new Weight(10.10m), SexOfPet.Male, "PetName1");
        var pet2 = new Pet(id,15, "Yellow", new Weight(15.10m), SexOfPet.Female, "PetName2");

        //Act

        // Assert
        Assert.True(pet1.Equals(pet2));
    }

    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        // Arrange
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, 10, "Green", new Weight(10.10m), SexOfPet.Male, "PetName1");
        var pet2 = new Pet(id, 15, "Yellow", new Weight(15.10m), SexOfPet.Female, "PetName2");

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
        var pet1 = new Pet(id1, 10, "Green", new Weight(10.10m), SexOfPet.Male, "PetName1");
        var pet2 = new Pet(id2, 15, "Yellow", new Weight(15.10m), SexOfPet.Female, "PetName2");

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
        var weight1 = new Weight(10.10m);
        var weight2 = new Weight(10.10m);
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
}
