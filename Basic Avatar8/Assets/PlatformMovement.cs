using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
   public GameObject startPos;
    public GameObject endPos;
    public float speed = 30.0f;
    private bool to;
    private GameObject player;

    public Char_Move Move;
    // Use this for initialization

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
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
        if (!Move.axisUse)
        {

            if (other.gameObject == player)
            {
                player.transform.position = transform.position;


            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
