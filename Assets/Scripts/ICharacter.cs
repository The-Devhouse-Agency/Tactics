using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    public float health { get; set; }

    public int attackRange { get; set; }
    public int cubeMovementSquare { get; set; }
}
