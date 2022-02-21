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

    // Start is called before the first frame update
    void Start()
    {
        
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

                switch (hit.transform.name)
                {
                    case "Goblins_Ranged":
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth/ hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                        selectedName.text = "Goblin Archer";
                        break;
                    case "Goblins_Melee":
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                        selectedName.text = "Goblin Melee";
                        break;
                    case "Humans_Melee":
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Warrior>().Portrait;
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Warrior>().CurrentHealth / hit.transform.gameObject.GetComponent<Warrior>().MaxHealth;
                        selectedName.text = "Human Melee"; 
                        break;
                    case "Humans_Ranged":
                        print(hit.transform.gameObject.GetComponent<Archer>().CurrentHealth);
                        selectedPortrait.sprite = hit.transform.gameObject.GetComponent<Archer>().Portrait;    
                        healthMeter.fillAmount = hit.transform.gameObject.GetComponent<Archer>().CurrentHealth / hit.transform.gameObject.GetComponent<Archer>().MaxHealth;
                        selectedName.text = "Archer";
                        break;
                    default:
                        break;
                }
         
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //StartCoroutine(ScaleMe(hit.transform));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                switch (hit.transform.name)
                {
                    case "Goblins_Ranged":
                        hit.transform.gameObject.GetComponent<Archer>().TakeDamage(5);
                        break;
                    case "Goblins_Melee":
                        print("DAS");
                        break;
                    case "Humans_Melee":
                        print("DAS");
                        break;
                    case "Humans_Ranged":
                        hit.transform.gameObject.GetComponent<Archer>().TakeDamage(5);
                        print(hit.transform.gameObject.GetComponent<Archer>().CurrentHealth);
                        print(hit.transform.gameObject.GetComponent<Archer>().MaxHealth);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
