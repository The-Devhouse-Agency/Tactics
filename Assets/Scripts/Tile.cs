using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject attackBlinker;
    [SerializeField] GameObject movementBlinker;

    [SerializeField] float highlightSpeed;

    public bool IsHighLighting { get; set; }

    public void TurnOnHighLighting()
    {
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

}
