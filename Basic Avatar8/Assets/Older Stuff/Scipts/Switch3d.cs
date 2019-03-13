using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch3d : MonoBehaviour {

    public CutScene scene;
    public Transform player;
    public Transform to3D;
    public Switch2D Switch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene.TrackCam.SetActive(false);
            scene.maincam.SetActive(true);
            Switch.isTrack = false ;

            Vector3 temp1 = player.position;
            temp1.x = to3D.transform.position.x;
            temp1.y = to3D.transform.position.y;
            temp1.z = to3D.transform.position.z;
            player.position = temp1;

            Switch.isTrack = false;

        }

    }
}
