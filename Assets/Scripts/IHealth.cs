using System;

public interface IHealth
{
    event Action<float, float> Changed;
    float Current { get; }
    float Max { get; }
}