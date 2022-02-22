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
        if (RayCastSelectCharacter.Instance.CurrentCharacterSelected == null) { return; }

        RayCastSelectCharacter.Instance.IsInMovingAction = true;
        RayCastSelectCharacter.Instance.IsInAttackAction = false;
        RayCastSelectCharacter.Instance.CurrentCharacterSelected.HighlightMovement();
    }

    public void ShowPossibleAttack()
    {
        if (RayCastSelectCharacter.Instance.CurrentCharacterSelected == null) { return; }

        RayCastSelectCharacter.Instance.IsInAttackAction = true;
        RayCastSelectCharacter.Instance.IsInMovingAction = false;
        RayCastSelectCharacter.Instance.CurrentCharacterSelected.HighlightAttackRange();
    }
}
