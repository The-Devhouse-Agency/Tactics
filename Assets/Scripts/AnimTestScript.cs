using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTestScript : MonoBehaviour
{

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            myAnimator.SetInteger("State", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            myAnimator.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            myAnimator.SetInteger("State", 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            myAnimator.SetInteger("State", 0);
        }
    }

    public void SetAnimParameter(int value)
    {
        myAnimator.SetInteger("State", value);
    }
}
