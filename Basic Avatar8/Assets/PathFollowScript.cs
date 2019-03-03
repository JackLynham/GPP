using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowScript : MonoBehaviour
{
    public float speed = 3f;
    public Transform pathParent;
    Transform targetPoint;
    int index;
    public Char_Move move;
   public  Switch2D Switch;
    public Rigidbody rigidbody;
    public Transform player;

    //public Transform cube;
    //public float dist2;
    //Vector3 initPos;

    private Vector3 targetPostion;

   // distanceUp
        //distanceAway

    //public Transform playerPos;


    private void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int i = 0; i < pathParent.childCount; i++)
        {
            from = pathParent.GetChild(i).position;
            if (!move.backwards)
            {
                to = pathParent.GetChild((i + 1) % pathParent.childCount).position;
                Gizmos.color = new Color(1, 0, 0);
                Gizmos.DrawLine(from, to);
            }

          

        }
    }

    private void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
        //initPos = transform.position; dist2 = cube.lossyScale.x / 2;
    }

    private void Update()
    {

        //player.transform.Translate(Vector3.left);
        // targetPostion = targetPoint.position + Vector3.left * distanceUp - targetPoint.forward * distanceAway;

        //if(Switch.isTrack ==false)
        //{
        //    rigidbody.constraints = RigidbodyConstraints.
        //}
        if(Switch.isTrack == false)
        {
            rigidbody.constraints = RigidbodyConstraints.None;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (Switch.isTrack)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        
            if (move.axisUse)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            }

            //Just before next node CHange node 

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                index++;

                index %= pathParent.childCount;
                targetPoint = pathParent.GetChild(index);
            }
        }




    }
}



