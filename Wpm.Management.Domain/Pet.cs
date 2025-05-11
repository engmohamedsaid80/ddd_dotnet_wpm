namespace Wpm.Management.Domain;
public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }

    public string Color { get; init; }
    public Weight Weight { get; init; }
    public SexOfPet SexOfPet { get; init; }
    public Pet(Guid id,
               int age,
               string color,
               Weight weight,
               SexOfPet sexOfPet,
               string name)
    {
        Id = id;
        Age = age;
        Color = color;
        Weight = weight;
        SexOfPet = sexOfPet;
        Name = name;
    }
}

public enum SexOfPet
{
    Male,
    Female
}
