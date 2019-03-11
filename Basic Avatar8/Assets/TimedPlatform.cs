using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimedPlatform : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;
    public float speed = 30.0f;
    private bool to;
    private GameObject player;
    public CutScene scene;
    public Char_Move Move;
    public CamTest test;
    Transform aa;
    public float time = 8;
    public bool TimerEnabled;
    public Text Text;
    public GameObject Platform;
    // Use this for initialization

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Text.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        player.transform.parent = transform.transform;
        transform.position += Vector3.down * 50 * Time.deltaTime;
        TimerEnabled = true;

    }
    private void Update()
    {
        if(TimerEnabled)
        {
            Text.enabled = true;
      
        }
        if(time <= 0)
        {
            Platform.SetActive(false);
          
        }

        if (!to)
        {
            if (transform.position == startPos.transform.position)
            {
                to = true;
            }
        }

        if (to)
        {
            if (transform.position == endPos.transform.position)
            {
                to = false;
            }
        }


    }

    private void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        if (to)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
        }

        if (!to)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, step);
        }

    }

    void OnCollisionStay(Collision other)
    {

        if (!Move.axisUse || !Move.axisHor)
        {

            if (other.gameObject == player)
            {

                test.CutToShot();
                scene.TrackCam.SetActive(true);
                scene.maincam.SetActive(false);
                time -= Time.deltaTime;
                Text.text = "Time: " + time.ToString();
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        TimerEnabled = false;
        if (other.gameObject == player)
        {
            player.transform.parent = null;

            scene.TrackCam.SetActive(false);
            scene.maincam.SetActive(true);
            Text.enabled = false;
        }
    }
}