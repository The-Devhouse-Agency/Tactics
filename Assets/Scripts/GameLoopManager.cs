using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject characterHolder;
    public List<Archer> archers = new List<Archer>();
    public List<Warrior> warriors = new List<Warrior>();

    void Start()
    {
        foreach (Transform child in characterHolder.transform)
        {
            if (child.GetComponent<Archer>())
                archers.Add(child.GetComponent<Archer>());
            else if (child.GetComponent<Warrior>())
                warriors.Add(child.GetComponent<Warrior>());
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckForDeadUnits()
    {
        foreach (Archer archer in archers)
        {
            if (archer.CurrentHealth <= 0)
                archers.Remove(archer);
        }
        foreach (Warrior warrior in warriors)
        {
            if (warrior.CurrentHealth <= 0)
                warriors.Remove(warrior);
        }

        if(warriors.Count <= 0 && archers.Count <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        print("game has ended");
    }
}
