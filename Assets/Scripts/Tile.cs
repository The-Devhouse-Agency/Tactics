using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject attackBlinker;
    [SerializeField] GameObject movementBlinker;

    [SerializeField] float highlightSpeed;

    public bool IsHighLighting { get; set; }

    public void TurnOnMovementHighlighting()
    {
        IsHighLighting = false;
        IsHighLighting = true;
        StartCoroutine(HighLightTile());
        IEnumerator HighLightTile()
        {
            while (IsHighLighting)
            {
                yield return new WaitForSeconds(highlightSpeed);
                movementBlinker.gameObject.SetActive(!movementBlinker.activeInHierarchy);
            }

            movementBlinker.gameObject.SetActive(false);
        }
    }

    public void TurnOnAttackHighlighting()
    {
        IsHighLighting = false;
        IsHighLighting = true;
        StartCoroutine(HighLightTile());
        IEnumerator HighLightTile()
        {
            while (IsHighLighting)
            {
                yield return new WaitForSeconds(highlightSpeed);
                attackBlinker.gameObject.SetActive(!attackBlinker.activeInHierarchy);
            }

            attackBlinker.gameObject.SetActive(false);
        }
    }
}
