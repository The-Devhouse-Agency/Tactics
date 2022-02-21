using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject attackBlinker;
    [SerializeField] GameObject movementBlinker;

    [SerializeField] float highlightSpeed;

    public static bool IsHighLighting { get; set; }
    public bool ActionAllowedOnTile { get; set; } //Action as in able to move to tile and attack

    IEnumerator currentFlashingAnimation;

    public void TurnOnMovementHighlighting()
    {
        IsHighLighting = false;
        IsHighLighting = true;
        currentFlashingAnimation = HighLightTile();

        StartCoroutine(currentFlashingAnimation);
        IEnumerator HighLightTile()
        {
            ActionAllowedOnTile = true;

            while (IsHighLighting)
            {
                yield return new WaitForSeconds(highlightSpeed);
                movementBlinker.gameObject.SetActive(!movementBlinker.activeInHierarchy);
            }

            ActionAllowedOnTile = false;
            movementBlinker.gameObject.SetActive(false);
        }
    }

    public void TurnOnAttackHighlighting()
    {
        IsHighLighting = false;
        IsHighLighting = true;
        currentFlashingAnimation = HighLightTile();

        StartCoroutine(currentFlashingAnimation);
        IEnumerator HighLightTile()
        {
            ActionAllowedOnTile = true;

            while (IsHighLighting)
            {
                yield return new WaitForSeconds(highlightSpeed);
                attackBlinker.gameObject.SetActive(!attackBlinker.activeInHierarchy);
            }

            ActionAllowedOnTile = false;
            attackBlinker.gameObject.SetActive(false);
        }
    }

    public void TurnOffAllHighlighting()
    {
        if(currentFlashingAnimation != null)
            StopCoroutine(currentFlashingAnimation);
    }
}
