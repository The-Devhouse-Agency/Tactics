using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Character : MonoBehaviour
{
    [SerializeField] int health, movementRange, attackRange, attackDamage;

    const float MOVEMENT_ANIM_SPEED = 2;

    public int Health { get; set; }
    public int MovementRange { get; set; }
    public int AttackRange { get; set; }
    public int AttackDamage { get; set; }

    public abstract void OnDeath();
    public abstract void Attack();

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

    public void HighlightMovement()
    {

    }

    public void HighlightAttackRange()
    {

    }

    public void OnMovement(Vector3 targetPosition) => transform.DOMoveX(targetPosition.x, MOVEMENT_ANIM_SPEED).OnComplete(() => transform.DOMoveX(targetPosition.z, MOVEMENT_ANIM_SPEED));
}