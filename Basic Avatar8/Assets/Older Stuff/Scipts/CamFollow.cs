using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.1f;

    public Vector3 offset;

    public Char_Move Move;

    public GameObject cam;

     void FixedUpdate()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredpos, smoothSpeed *Time.deltaTime);
        transform.position = smoothedPos;

    }
    
    //public void MoveDirection(Vector3 direction)
    //{
    //    var newDirection = Quaternion.LookRotation(Camera.main.transform.position - transform.position).eulerAngles;
    //    newDirection.x = 0;
    //    newDirection.z = 0;

    //    cam.transform.rotation = Quaternion.Euler(newDirection);
    //    transform.Translate(-direction * Time.deltaTime * Move.moveSpeed, cam.transform);

    //    Quaternion newRotation = Quaternion.LookRotation(-direction);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation * cam.transform.rotation, Time.deltaTime * 2);
    //}

}
