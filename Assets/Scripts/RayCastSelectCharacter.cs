using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSelectCharacter : MonoBehaviour
{
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
                        print("DAS");
                        break;
                    case "Goblins_Melee":
                        print("DAS");
                        break;
                    case "Humans_Ranged":
                        print("DAS");
                        break;
                    case "Humans_Ranged":
                        print("DAS");
                        break;
                    default:
                        break;
                }
         
            }
        }
    }
}
