using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereaConroller : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2.0f;
    //Zoom 
 
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float yawSpeed = 250f;

   private float currentZoom = 10f;
    private float currentYaw = 0f;
    // Use this for initialization
     void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetKey(KeyCode.LeftArrow) ||(Input.GetKey(KeyCode.RightArrow)))
        {
            currentYaw += Input.GetAxis("CamTurn") * yawSpeed * Time.deltaTime;
        }
     
    }
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);

    }
}
