using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void OnNewState();
    public static event OnNewState onMainMenu, onStartEvent;

    [SerializeField] Button startButton, attackButton, moveButton, endTurnButton;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void ShowPossibleMovement()
    {
        RayCastSelectCharacter.Instance.CurrentCharacterSelected.HighlightMovement();
    }

    public void ShowPossibleAttack()
    {
        RayCastSelectCharacter.Instance.CurrentCharacterSelected.HighlightAttackRange();
    }
}
