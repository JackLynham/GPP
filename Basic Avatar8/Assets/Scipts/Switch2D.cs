using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2D : MonoBehaviour
{

    public CutScene scene;
    public bool isTrack = false;
    public Transform player;
    public Transform to2D;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scene.TrackCam.SetActive(true);
            scene.maincam.SetActive(false);
            isTrack = true;

            Vector3 temp = player.position;
            temp.x = to2D.transform.position.x;
            temp.y = to2D.transform.position.y;
            temp.z = to2D.transform.position.z;
            player.position = temp;
        }

    }

}
