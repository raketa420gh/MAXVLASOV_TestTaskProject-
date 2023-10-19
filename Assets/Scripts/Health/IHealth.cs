using System;

public interface IHealth
{
    event Action OnOver;
        
    void Initialize(int maxHealth);
    void ChangeHealth(int value);
}