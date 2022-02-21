using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayCastSelectCharacter : MonoBehaviour
{
    public Image selectedPortrait;
    public Image healthMeter;
    public TextMeshProUGUI selectedName;
    public bool playerOneTurn = true;

    public Character CurrentCharacterSelected { get; set; }

    private static RayCastSelectCharacter _instance;
    public static RayCastSelectCharacter Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void EndTurn()
    {
        playerOneTurn = !playerOneTurn;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                if (CurrentCharacterSelected)
                {
                    CurrentCharacterSelected.HighlightAttackRange(true);
                    CurrentCharacterSelected.HighlightMovement(true);
                }


                switch (hit.transform.name)
                {
                    case "Goblins_Ranged":
                        if (playerOneTurn)
                            return;
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth/ hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                        selectedName.text = "Goblin Archer";
                        break;
                    case "Goblins_Melee":
                        if (playerOneTurn)
                            return;
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                        selectedName.text = "Goblin Melee";
                        break;
                    case "Humans_Melee":
                        if (!playerOneTurn)
                            return;
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                        selectedName.text = "Human Melee"; 
                        break;
                    case "Humans_Ranged":
                        if (!playerOneTurn)
                            return;
                        print(hit.transform.gameObject.GetComponent<Archer>().CurrentHealth);
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;    
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth / hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                        selectedName.text = "Archer";
                        break;
                    default:
                        break;
                }

                CurrentCharacterSelected = hit.transform.gameObject.GetComponent<Character>();

                if(hit.collider.GetComponent<Tile>())
                {
                    if (hit.collider.GetComponent<Tile>().ActionAllowedOnTile)
                    {
                        Debug.Log("Test: " + hit.collider.GetComponent<Tile>().transform.position);
                        CurrentCharacterSelected.Move(hit.collider.GetComponent<Tile>().transform.position);
                    }

                }
            }
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 100.0f))
        //    {
        //        //StartCoroutine(ScaleMe(hit.transform));
        //        Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

        //        switch (hit.transform.name)
        //        {
        //            case "Goblins_Ranged":
        //                hit.transform.gameObject.GetComponent<Archer>().TakeDamage(5);
        //                break;
        //            case "Goblins_Melee":
        //                print("DAS");
        //                break;
        //            case "Humans_Melee":
        //                print("DAS");
        //                break;
        //            case "Humans_Ranged":
        //                hit.transform.gameObject.GetComponent<Archer>().TakeDamage(5);
        //                print(hit.transform.gameObject.GetComponent<Archer>().CurrentHealth);
        //                print(hit.transform.gameObject.GetComponent<Archer>().MaxHealth);
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        }
    }
