namespace Wpm.Management.Domain;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }

    bool IEquatable<Entity>.Equals(Entity? other)
    {
        return other?.Id == Id;
    }

    public override bool Equals(object obj)
    {
        return ((IEquatable<Entity>)this).Equals(obj as Entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return left?.Id == right?.Id;
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return left?.Id != right?.Id;
    }
}
