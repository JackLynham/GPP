using UnityEngine.EventSystems;
using UnityEngine;

/* Controls the player. Here we choose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public Interactable focus;
    public float moveSpeed = 20f;
    public float turnSpeed = 50f;
    // Filter out everything not walkable
    public LayerMask movementMask;	

	Camera cam;			
	PlayerMotor motor;
    private Animator anim;
 
    // Get references
    void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            anim.Play("Run");
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            anim.Play("Backward");
        }
        if (Input.GetAxisRaw("Vertical") == 0 && !Input.GetKey(KeyCode.Space))
        {

            if (Input.GetKey(KeyCode.Alpha1))
            {
                anim.Play("Attack");
                //  Debug.Log("b");
              
            }
            else
            {
            anim.Play("Idle");
            }
          
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Rotate(Vector3.down * -turnSpeed * Time.deltaTime);
      
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);

        }

    }
}
