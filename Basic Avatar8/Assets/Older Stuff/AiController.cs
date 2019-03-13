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
           
            if(distance<= agent.stoppingDistance)
            {
                //attack and Face target
                FaceTarget();
            }
        }
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation , lookRotation, Time.deltaTime *5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRaidus);
        
    }
}
