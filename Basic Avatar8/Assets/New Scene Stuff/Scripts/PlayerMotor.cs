using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    private bool test = false;
	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}

    public void Update()
    {
        //Debug.Log(newTarget);
        // Debug.Log(target);
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    public void MovetoPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactble newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
          target = newTarget.transform;
          agent.updateRotation = false;

        if (test)
        {
            newTarget = null;
            //Debug.Log(newTarget);
            
        }
     
    }

    public void StopFollowingTarget()
    {
        target = null;
        test = true;
        agent.stoppingDistance = 3f;
        agent.updateRotation = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime *5f);
    }
}
