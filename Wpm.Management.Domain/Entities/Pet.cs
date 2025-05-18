using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;
public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }

    public string Color { get; init; }
    public Weight Weight { get; private set; }
    public WeightClass WeightClass { get; private set; }
    public SexOfPet SexOfPet { get; init; }

    public BreedId BreedId { get; init; }
    public Pet(Guid id,
               int age,
               string color,
               SexOfPet sexOfPet,
               string name,
               BreedId breedId)
    {
        Id = id;
        Age = age;
        Color = color;
        SexOfPet = sexOfPet;
        Name = name;
        BreedId = breedId;
    }

    public void SetWeight(Weight weight, IBreedService breedService)
    {
        Weight = weight;
        SetWeightClass(breedService);
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Value);

        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
            SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
            _ => throw new NotImplementedException()
        };

        WeightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClass.Underweight,
            _ when Weight.Value > to => WeightClass.Overweight,
            _ => WeightClass.Ideal,
        };
    }
}

public enum SexOfPet
{
    Male,
    Female
}

public enum WeightClass
{
    Unkown,
    Ideal,
    Underweight,
    Overweight,
}
