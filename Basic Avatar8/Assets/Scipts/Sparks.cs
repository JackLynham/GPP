using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{

    public AudioClip sparkclip;
    public AudioSource sparkSource;
    public ButtonScript button;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(button.dooropen == true)
        {
            sparkSource.clip = sparkclip;
            sparkSource.Play();
        }
    }
}
