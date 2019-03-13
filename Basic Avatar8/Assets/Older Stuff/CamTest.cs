using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    public Vector3 focalPoint;
    public Transform player;
   // Transform camTrans;

 
    public void CutToShot ()
    {
        transform.LookAt(focalPoint);
       // Camera.main.transform.localPosition = transform.position;
        //Camera.main.transform.localRotation = transform.rotation;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, focalPoint);
    }

    private void FixedUpdate()
    {
          focalPoint = player.position;
    }

   


    
}
