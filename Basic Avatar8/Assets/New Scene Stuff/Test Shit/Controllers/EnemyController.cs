using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRaidus = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
   

    private Animator anim;
    // Use this for initialization
    void Start()
    {
        target = TrackPlayer.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Slime Jump");
 
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRaidus)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                anim.Play("Idle");
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }
                //attack and Face target
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRaidus);

    }
}
