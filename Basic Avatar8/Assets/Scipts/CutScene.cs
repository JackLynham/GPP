using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour {
    public GameObject cutsceneCam;
    public GameObject maincam;
    public GameObject buttonCam;
    public GameObject buttonObj;
 public GameObject player;
    public GameObject TrackCam;
    public GameObject Switch2D;
    public ButtonScript button;
   
    // Use this for initialization
    public AudioClip sparkclip;
    public AudioSource sparkSource;

    public Char_Move chr;
    public ParticleSystem Sparks1;
    public ParticleSystem Sparks2;
    public ParticleSystem Sparks3;
    public ParticleSystem Spark4;
    void Start ()
    {
        maincam.SetActive(true);
        cutsceneCam.SetActive(false);
        Sparks1.Stop();
        Sparks2.Stop();
        Sparks3.Stop();
        Spark4.Stop();
        buttonCam.SetActive(false);
        TrackCam.SetActive(false);
    }

    IEnumerator TheSequence()
    {
       buttonCam.SetActive(true);
        maincam.SetActive(false);
        yield return new WaitForSeconds(6);

        cutsceneCam.SetActive (true);
        buttonCam.SetActive(false);
       
        Sparkson();

        yield return  new WaitForSeconds(6);
        maincam.SetActive(true);
        cutsceneCam.SetActive(false);

        SparksOff();
    }

    // Update is called once per frame
    void Update ()
    {
		
     if (button.test)
        {
            Cutscene();
        }

	}

    void Sparkson()
    {
        sparkSource.clip = sparkclip;
        sparkSource.Play();
        Sparks1.Play();
        Sparks2.Play();
        Sparks3.Play();
        Spark4.Play();
    }

    void SparksOff()
    {
        sparkSource.Stop();
        Sparks1.Stop();
        Sparks2.Stop();
        Sparks3.Stop();
        Spark4.Stop();
    }
    void Cutscene()
    {
       if(button.dooropen == true)
        {
             StartCoroutine (TheSequence());
              
        }
    }
}
   