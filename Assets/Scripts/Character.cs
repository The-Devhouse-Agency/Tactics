using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

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

    public bool HasMoved { get; set; }
    public bool HasAttacked { get; set; }

    public abstract void OnDeath();
    public abstract void Attack();

    private void Start()
    {
        AssignStats(maxHealth, currentHealth, movementRange, attackRange, attackDamage, portrait);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            HighlightMovement();

        if (Input.GetKeyDown(KeyCode.Q))
            HighlightAttackRange();
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

    public void HighlightMovement(bool isTurningOffHighLighting = false)
    {
        if (HasMoved) { return; }

        List<Vector2> possiblePositions = new List<Vector2>();

        for (int numberOfTilesToMove = 0; numberOfTilesToMove <= MovementRange; numberOfTilesToMove++)
        {
            possiblePositions.Add(new Vector2(transform.position.x + numberOfTilesToMove, transform.position.z));
            possiblePositions.Add(new Vector2(transform.position.x - numberOfTilesToMove, transform.position.z));

            for (int numberOfDiagnolTilesToMove = 0; numberOfDiagnolTilesToMove <= MovementRange; numberOfDiagnolTilesToMove++)
            {
                possiblePositions.Add(new Vector2(transform.position.x + numberOfTilesToMove, transform.position.z + numberOfDiagnolTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x - numberOfTilesToMove, transform.position.z - numberOfDiagnolTilesToMove));

                possiblePositions.Add(new Vector2(transform.position.x + numberOfTilesToMove, transform.position.z + numberOfDiagnolTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x - numberOfTilesToMove, transform.position.z - numberOfDiagnolTilesToMove));

                possiblePositions.Add(new Vector2(transform.position.x - numberOfTilesToMove, transform.position.z + numberOfDiagnolTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x + numberOfTilesToMove, transform.position.z - numberOfDiagnolTilesToMove));
            }
        }

        for (int numberOfTilesToMove = 0; numberOfTilesToMove <= MovementRange; numberOfTilesToMove++)
        {
            possiblePositions.Add(new Vector2(transform.position.x, transform.position.z + numberOfTilesToMove));
            possiblePositions.Add(new Vector2(transform.position.x, transform.position.z - numberOfTilesToMove));

            for (int numberOfDiagnolTilesToMove = 0; numberOfDiagnolTilesToMove <= MovementRange; numberOfDiagnolTilesToMove++)
            {
                possiblePositions.Add(new Vector2(transform.position.x + numberOfDiagnolTilesToMove, transform.position.z + numberOfTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x - numberOfDiagnolTilesToMove, transform.position.z - numberOfTilesToMove));

                possiblePositions.Add(new Vector2(transform.position.x + numberOfDiagnolTilesToMove, transform.position.z - numberOfTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x - numberOfDiagnolTilesToMove, transform.position.z + numberOfTilesToMove));

                possiblePositions.Add(new Vector2(transform.position.x - numberOfDiagnolTilesToMove, transform.position.z + numberOfTilesToMove));
                possiblePositions.Add(new Vector2(transform.position.x + numberOfDiagnolTilesToMove, transform.position.z - numberOfTilesToMove));
            }
        }

        List<Vector2> finalPossiblePositions = possiblePositions.Distinct().ToList();

        foreach (var value in finalPossiblePositions)
        {
            Debug.Log("Points: " + value);
        }

        foreach (var pos in finalPossiblePositions)
        {
            if (pos.x < 0 || pos.x >= LevelGenerator.Instance.gridSize)
                continue;

            if (pos.y < 0 || pos.y >= LevelGenerator.Instance.gridSize)
                continue;

            var tile = LevelGenerator.Instance.floorGridTiles[(int)pos.x, (int)pos.y];
            Tile.IsHighLighting = true;

            if(!isTurningOffHighLighting)
                tile.TurnOnMovementHighlighting();
            else
                tile.TurnOffAllHighlighting();
        }
    }

    public void HighlightAttackRange(bool isTurningOffHighLighting = false)
    {
        if (HasAttacked) { return; }

        List<Vector2> possiblePositions = new List<Vector2>();

        for (int numberOfTilesToMove = 0; numberOfTilesToMove < MovementRange; numberOfTilesToMove++)
        {
            possiblePositions.Add(new Vector2(transform.position.x + numberOfTilesToMove, transform.position.z));
            possiblePositions.Add(new Vector2(transform.position.x - numberOfTilesToMove, transform.position.z));
        }

        for (int numberOfTilesToMove = 0; numberOfTilesToMove < MovementRange; numberOfTilesToMove++)
        {
            possiblePositions.Add(new Vector2(transform.position.x, transform.position.z + numberOfTilesToMove));
            possiblePositions.Add(new Vector2(transform.position.x, transform.position.z - numberOfTilesToMove));
        }

        List<Vector2> finalPossiblePositions = possiblePositions.Distinct().ToList();

        foreach (var pos in finalPossiblePositions)
        {
            if (pos.x < 0 || pos.x > LevelGenerator.Instance.gridSize - 1)
                continue;

            if (pos.y < 0 || pos.y > LevelGenerator.Instance.gridSize - 1)
                continue;

            var tile = LevelGenerator.Instance.floorGridTiles[(int)pos.x, (int)pos.y];

            if (!isTurningOffHighLighting)
            {
                Tile.IsHighLighting = true;
                tile.TurnOnAttackHighlighting();
            }
            else
                tile.TurnOffAllHighlighting();

        }
    }

    public void Move(Vector3 targetPosition)
    {
        if(!HasMoved)
        {
            transform.DOMoveX(targetPosition.x, MOVEMENT_ANIM_SPEED).OnComplete(() => transform.DOMoveZ(targetPosition.z, MOVEMENT_ANIM_SPEED));
            HighlightMovement(true);
            HighlightAttackRange(true);
            HasMoved = true;
        }
    }
}