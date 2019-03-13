using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInteraction : MonoBehaviour
{
    private int count;
    public Text countText;
    public bool speedBoost = false;
    public bool doubleJump;
    //Char_Move move;

    [Range(10.0f, 20.0f)]
    public float sprintSpeed;
    private float timeleft = 2.0f;

    //Audio 
   // public AudioClip coinClip;
    //public AudioSource coinSource;
    public AudioClip speedclip;
    public AudioSource speedSource;
    public AudioClip jumpclip;
    public AudioSource jumpSource;

    public TrailRenderer trail;
    // Use this for initialization
    void Start ()
    {
        CountText();
        trail.emitting = false;
    }
	
	// Update is called once per frame
	void Update ()

    {

        if (speedBoost == true)
        {
            timeleft -= Time.deltaTime;
            trail.emitting = true;


            if (timeleft > 0)
            {
                transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
                
            }
            if(timeleft <=0)
            {
                speedBoost = false;
            }

            if(!speedBoost)
            {
                timeleft = 2.0f;
                trail.emitting = false;

            }
        }

       


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag( "SpeedBoost" ))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            CountText();
            speedBoost = true;
            //coinSource.clip = coinClip;
            //coinSource.Play();
            speedSource.clip = speedclip;
         
            speedSource.Play();

        }

        if(other.gameObject.CompareTag("DoubleJump"))
        {
            other.gameObject.SetActive(false);
            doubleJump = true;
            count = count + 1;
            CountText();
            // coinSource.clip = coinClip;
            // coinSource.Play();
        

        }


    }

    
    void CountText()
    {
        countText.text = "Count: " + count.ToString();
    }


     void OnCollisionEnter(Collision collision)
    {
        
    }
}
