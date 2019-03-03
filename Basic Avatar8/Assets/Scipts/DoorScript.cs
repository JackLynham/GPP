using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {


   public  ButtonScript button;
    public Animator doorAnimator;
    public CutScene scene;
	// Use this for initialization
	void Start ()
    {
        doorAnimator  = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (button.dooropen == true)
        {
            
            doorAnimator.SetBool("open", true);
        }

        if (button.dooropen == false)
        {

            doorAnimator.SetBool("open", false);
           
        }

       
    }
}
