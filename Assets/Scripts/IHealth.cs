using System;

public interface IHealth
{
    float Current { get; }
    float Max { get; }
    event Action OnHealthChanged;
}