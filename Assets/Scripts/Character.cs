using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] int health, movementRange, attackRange, attackDamage;

    public int Health { get; set; }
    public int MovementRange { get; set; }
    public int AttackRange { get; set; }
    public int AttackDamage { get; set; }

    private void Start()
    {
        AssignStats(health, movementRange, attackRange, attackDamage);
    }

    /// <summary>
    /// Make into SO later
    /// </summary>
    /// <param name="health"></param>
    /// <param name="movementRange"></param>
    /// <param name="attackRange"></param>
    /// <param name="attackDamage"></param>
    public void AssignStats(int health, int movementRange, int attackRange, int attackDamage)
    {
        Health = health;
        MovementRange = movementRange;
        AttackRange = attackRange;
        AttackDamage = attackDamage;
    }

    public void TakeDamage(int amountOfDamage)
    {
        Health -= amountOfDamage;
    }
}