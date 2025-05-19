namespace Wpm.SharedKernel;

public record Weight
{
    public decimal Value { get; init; }
    public Weight(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative.");

        Value = value;
    }

    public static implicit operator Weight(decimal value) => new Weight(value);
}
