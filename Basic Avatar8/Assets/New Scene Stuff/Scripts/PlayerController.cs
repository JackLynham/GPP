using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
     public PlayerMotor motor;
    public float moveSpeed = 10f;
    public float turnSpeed = 150f;

    public Interactble focus;
    public Interactble bgh;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            //motor.StopFollowingTarget();
            bgh.OnDeFocused();
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            motor.StopFollowingTarget();
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Rotate(Vector3.down * -turnSpeed * Time.deltaTime);


        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        
        //Collecting Stuff

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactble intera = hit.collider.GetComponent<Interactble>();
                //Foucs on interactble
                if (intera != null)
                {
                    SetFocus(intera);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                RemoveFocus();
            }
        }
    }

    public void SetFocus(Interactble newFocus)
    {
        if (focus!= null)
            {
             focus.OnDeFocused();
            }
        if(newFocus!= focus)
        {
           
      
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
   
        newFocus.Onfocused(transform);
       
    }
    public void RemoveFocus()
    {

        focus = null;
        motor.StopFollowingTarget();
       

        if (focus != null)
        {
            focus.OnDeFocused();
        }
    }

    
}
