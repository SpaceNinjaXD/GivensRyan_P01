using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy, IDamagable
{
    [SerializeField] protected int mHealth;
    public int Health
    {
        get => mHealth;
        set => mHealth = value; }

    public void Damage(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Death();
        }
        Debug.Log("Current Boss Health is " + Health.ToString()); ;
    }

    
}
