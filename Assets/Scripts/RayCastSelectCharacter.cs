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

    public bool IsInMovingAction { get; set; }
    public bool IsInAttackAction { get; set; }

    public Character CurrentCharacterSelected;

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
        IsInAttackAction = false;
        IsInMovingAction = false;

        Character[] characters = FindObjectsOfType<Character>();
        foreach(var character in characters)
        {
            character.HasAttacked = false;
            character.HasMoved = false;
        }
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

                if (CurrentCharacterSelected && (IsInAttackAction || IsInMovingAction))
                {
                    CurrentCharacterSelected.HighlightAttackRange(true);
                    CurrentCharacterSelected.HighlightMovement(true);
                }

                if(!IsInAttackAction)
                {
                    switch (hit.transform.name)
                    {
                        case "Goblins_Ranged":
                            if (playerOneTurn)
                                return;
                            selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;
                            healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth / hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                            selectedName.text = "Goblin Archer";
                            CurrentCharacterSelected = hit.transform.gameObject.GetComponent<Character>();
                            break;
                        case "Goblins_Melee":
                            if (playerOneTurn)
                                return;
                            selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                            healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                            selectedName.text = "Goblin Melee";
                            CurrentCharacterSelected = hit.transform.gameObject.GetComponent<Character>();
                            break;
                        case "Humans_Melee":
                            if (!playerOneTurn)
                                return;
                            selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                            healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                            selectedName.text = "Human Melee";
                            CurrentCharacterSelected = hit.transform.gameObject.GetComponent<Character>();
                            break;
                        case "Humans_Ranged":
                            if (!playerOneTurn)
                                return;
                            print(hit.transform.gameObject.GetComponent<Archer>().CurrentHealth);
                            selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;
                            healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth / hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                            selectedName.text = "Archer";
                            CurrentCharacterSelected = hit.transform.gameObject.GetComponent<Character>();
                            break;
                        default:
                            break;
                    }
                }

                if(hit.collider.GetComponent<Tile>() && IsInMovingAction)
                {
                    if (CurrentCharacterSelected.HasMoved) { return; }

                    if (hit.collider.GetComponent<Tile>().ActionAllowedOnTile)
                    {
                        Debug.Log("Test 1: " + hit.collider.GetComponent<Tile>().gameObject.name +" " + CurrentCharacterSelected);
                        CurrentCharacterSelected.Move(hit.collider.GetComponent<Tile>().transform.position);
                        CurrentCharacterSelected.HighlightMovement(true);
                        CurrentCharacterSelected.HasMoved = true;
                    }
                }

                if (hit.collider.GetComponent<Character>() && IsInAttackAction)
                {
                    if (CurrentCharacterSelected.HasAttacked) { return; }

                    if (LevelGenerator.Instance.floorGridTiles[(int)hit.collider.GetComponent<Character>().transform.position.x, (int)hit.collider.GetComponent<Character>().transform.position.z])
                    {
                        Debug.Log("Attacked with: " + CurrentCharacterSelected);
                        hit.collider.GetComponent<Character>().TakeDamage(10f); //Use Character Strength
                        CurrentCharacterSelected.GetComponent<AnimStateSwitcher>().SetAnimParameter(3);
                        CurrentCharacterSelected.HighlightAttackRange(true);
                        CurrentCharacterSelected.HasAttacked = true; //Need to reset on every end of round
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
