using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Character : MonoBehaviour
{
    [SerializeField] float maxHealth, currentHealth, movementRange, attackRange, attackDamage;
    [SerializeField] Sprite portrait;
    const float MOVEMENT_ANIM_SPEED = 2;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public float MovementRange { get; set; }
    public float AttackRange { get; set; }
    public float AttackDamage { get; set; }
    public Sprite Portrait { get; set; }


    public abstract void OnDeath();
    public abstract void Attack();

    private void Start()
    {
        AssignStats(maxHealth, currentHealth, movementRange, attackRange, attackDamage, portrait);
    }

    /// <summary>
    /// Make into SO later
    /// </summary>
    /// <param name="health"></param>
    /// <param name="movementRange"></param>
    /// <param name="attackRange"></param>
    /// <param name="attackDamage"></param>
    public void AssignStats(float maxHealth, float currentHealth, float movementRange, float attackRange, float attackDamage, Sprite portrait)
    {
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        MovementRange = movementRange;
        AttackRange = attackRange;
        AttackDamage = attackDamage;
        Portrait = portrait;
    }

    public void TakeDamage(float amountOfDamage)
    {
        CurrentHealth -= amountOfDamage;
    }

    public void HighlightMovement()
    {

    }

    public void HighlightAttackRange()
    {

    }

    public void OnMovement(Vector3 targetPosition) => transform.DOMoveX(targetPosition.x, MOVEMENT_ANIM_SPEED).OnComplete(() => transform.DOMoveX(targetPosition.z, MOVEMENT_ANIM_SPEED));
}