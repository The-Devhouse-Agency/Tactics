using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTurnManager : MonoBehaviour
{

    public Image playerTurnBackground;
    public TextMeshProUGUI playerTurnText;
    public RayCastSelectCharacter selectLogic;
    public Sprite[] backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectLogic.playerOneTurn)
        {
            playerTurnText.text = "Human Turn";
            playerTurnBackground.sprite = backgroundImage[0];
        }
        else
        {
            playerTurnText.text = "Goblin Turn";
            playerTurnBackground.sprite = backgroundImage[1];
        }
    }
}
