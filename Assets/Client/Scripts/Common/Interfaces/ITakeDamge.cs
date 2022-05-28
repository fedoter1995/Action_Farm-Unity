using System;
public interface ITakeDamge
{
    event Action<int> TakeDamageEvent;
    int HealthPoints { get; }
    void TakeDamage(int damage);
}
