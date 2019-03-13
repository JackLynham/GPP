using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    public AudioClip coinClip;
    public AudioSource coinSource;

    // Use this for initialization
    void Start()
    {
        coinSource.clip = coinClip;
        coinSource.Play();
       
    }

    // Update is called once per frame
}
