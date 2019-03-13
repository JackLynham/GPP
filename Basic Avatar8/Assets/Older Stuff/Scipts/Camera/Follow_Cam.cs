using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Cam : MonoBehaviour
{
    Vector3 offset;
    public GameObject target;


    private float MouseX;
    private float MouseY;
    private float MouseZ;


    void Start()
    {
        offset = transform.position  - target.transform.position ;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            float angleBetween = Vector3.Angle(Vector3.up, transform.forward);


            float dist = Vector3.Distance(target.transform.position, transform.position);
       
        }
    }

    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);

        transform.position = target.transform.position + (rotation * offset);

        transform.LookAt(target.transform);

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        MouseZ = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.Euler(0, MouseX, 0) * offset;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 Localright = target.transform.worldToLocalMatrix.MultiplyVector(transform.right);
            offset = Quaternion.AngleAxis(MouseY, Localright) * offset;
        }
        if (MouseZ > 0)
        {
            offset = Vector3.Scale(offset, new Vector3(1.05f, 1.05f, 1.05f));
        }

        if (MouseZ < 0)
        {
            offset = Vector3.Scale(offset, new Vector3(0.95f, 0.95f, 0.95f));
        }

    }
}