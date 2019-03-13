using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamScript : MonoBehaviour
{

    // Use this for initialization
    public float distanceAway;
    public float distanceUp;
    public float smooth;
    public Transform follow;
    private Vector3 targetPostion;
	void Start ()
    {
        follow = GameObject.FindWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            distanceAway = 20f;
            distanceUp = 20f;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            distanceAway = 10f;
            distanceUp = 4f;
        }
    }

    void LateUpdate()
    {
        targetPostion = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;
        Debug.DrawLine(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, - 1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPostion, Color.magenta);

        transform.position = Vector3.Lerp(transform.position, targetPostion, Time.deltaTime * smooth);
        transform.LookAt(follow);

    }
}
