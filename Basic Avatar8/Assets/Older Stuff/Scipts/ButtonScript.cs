using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool dooropen;
    private float timeleft = 2.0f;
    public bool test;
   // public ParticleSystem Sparks1;
   // public ParticleSystem Sparks2;
   //public ParticleSystem Sparks3;
   // public ParticleSystem Spark4;
    CutScene CutScene;
    //public AudioClip sparkclip;
    //public AudioSource sparkSource;

    private void Start()
    {
        dooropen = false;
        //Sparks1.Stop();
        //Sparks2.Stop();
        //Sparks3.Stop();
        //Spark4.Stop();
    }

    private void Update()
    {
     if (dooropen == true)
        {
            if(timeleft >1)
            {
                timeleft -= Time.deltaTime;
            }

            //Sparks1.Play();
            //Sparks2.Play();
            //Sparks3.Play();
            //Spark4.Play();

        }

     if(dooropen == false)
        {
            timeleft = 2;
            //Sparks1.Stop();
            //Sparks2.Stop();
            //Sparks3.Stop();
            //Spark4.Stop();
        }
 

    }
    void OnTriggerStay(Collider other)
    {
        
            if (Input.GetKeyDown(KeyCode.E))
            {
                transform.position -= new Vector3(0.5f, 0, 0 );
                 dooropen = true;
            test = true;

            }
            else
        {
            test = false; 
        }
        

            if (timeleft <= 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                transform.position += new Vector3(1.0f, 0, 0);


                dooropen = false;
                }
                   
              

            }

            
        
    }

   

 
}
