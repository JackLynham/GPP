using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiController : MonoBehaviour
{
    public float lookRaidus = 10f;

    Transform target;
     NavMeshAgent agent;
	// Use this for initialization
	void Start ()
    {
        target = TrackPlayer.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
       
    
	}
	
	// Update is called once per frame
	void Update () 
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if(distance <= lookRaidus)
        {
            agent.SetDestination(target.position);
        }
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRaidus);
        
    }
}
