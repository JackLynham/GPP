using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Char_Move : MonoBehaviour
{
    //Movement Editors 
    [Range(1.0f, 10.0f)]
    public float moveSpeed;
    [Range(100.0f, 300.0f)]
    public float turnSpeed;
    //Test 
    private float dampentime = 0.25f;
    private float hor = 0.0f;
    private float vert = 10.0f;
    private float speed = 0.0f;
    public bool axisUse = false;
    public bool axisHor = false;

    public float direction = 0f;


    //Jump Componants 
    public int maxjumps = 2;
    int jumps;
    float jumpforce = 5f;
    bool grounded;

    //Rigidbody Componants. 
    public Rigidbody rb;

    //Animator Values 
    private Animator anim;
    bool walk;
    bool attack;
    public bool backwards;
    bool jump;

    //Particle Systems
    public ParticleSystem dustCloud;

    //Audio 
    public AudioClip jumpclip;
    public AudioSource jumpSource;

    public AudioClip sparkclip;
    public AudioSource sparkSource;
    //Other Classes
    public CharacterInteraction interaction;
   public Camera camera;
    public CutScene scene;

 

     void Start()
    {
      anim = gameObject.GetComponent<Animator>();
        walk = false;
        attack = false;
        backwards = false;
        jump = false;

      
        dustCloud.Stop();

        if(anim.layerCount >= 2)
        {
            anim.SetLayerWeight(1, 1);
        }

       
    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Backwards", true);
            backwards = true;
        }

        //MovementVertical();

        // MovementHorizontal();


        if (anim)
        {
            hor = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");

            speed = new Vector2(hor, vert).sqrMagnitude;
            anim.SetFloat("Speed", speed);
            anim.SetFloat("Direction", hor, dampentime, Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);

            }

            //For Splines
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (axisUse == false)
                {
                    // Call your event function here.
                    axisUse = true;
                }
            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                axisUse = false;
            }

           if(scene.TrackCam)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }

        }

        WorldSpace(this.transform, camera.transform, ref turnSpeed, ref moveSpeed);

        //Combat

        if (Input.GetKey(KeyCode.P))
        {
            attack = true;
        }


        //Speed Boost Functionality.
        bool v = interaction.speedBoost;
        if (v)
        {
            walk = true;
        }

        //Jump 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            DoubleJump();
           

        }

    }

    public void WorldSpace(Transform root, Transform cam, ref float turnOut, ref float speedOut)
    {
        Vector3 rootTurn = root.forward;
      //  Vector3 dir = new Vector3(hor , 0, )



    }
     void MovementVertical()
    {
        //Foward and Backward
        if (Input.GetKey(KeyCode.W))

        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            walk = true;
            // follow.MoveDirection(Vector3.forward);
        }



        if (!Input.GetKey(KeyCode.W))
        {
            walk = false; 
        }
            if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            backwards = true;
           // follow.MoveDirection(Vector3.back);
        }
    }
    void MovementHorizontal()
    {
        //Left and Right 

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
            //follow.MoveDirection(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
           // follow.MoveDirection(Vector3.right);
        }

    }

    void Jump()
    {


        if (jumps > 0)
        {
            jumpSource.clip = jumpclip;
            jumpSource.Play();
            speed = 1;
                    

        }

        if (jumps > 0 && interaction.doubleJump == false)
        {
          
            rb.velocity = new Vector3(3, 10.0f, 0);
            dustCloud.Play();
            grounded = false;
            jumps = jumps - 2;
         
        }
        if (jumps == 0)
        {
            interaction.doubleJump = false;
            sparkSource.Stop();
            return;
        }
    }

    void DoubleJump()
    {
        if (interaction.doubleJump == true && jumps>0 )
        {
            rb.velocity = new Vector3(0, 10.0f, 0);
            grounded = false;
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            interaction.doubleJump = false;
            return;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            jumps = maxjumps;
            grounded = true;
        }
    }


     void OnTriggerStay(Collider other)
    { 
        MovementAnimations();
         
     }


    void OnTriggerExit(Collider other)
    {
        anim.SetBool("jump", true);
        anim.SetBool("Walk", false);

    }

   void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Walk", false);


    }
    void MovementAnimations()
    {

        //Jump
        if (jump == true)
        {
             anim.SetBool("jump", true);
            
        }
        if (jump == false)
        {
            anim.SetBool("jump", false);
        }

        else
        {
            DisableMove();
        }

        //Walk
        if (walk == true)
        {
           anim.SetBool("Walk", true);
        }
        if (walk == false)
        {
            anim.SetBool("Walk", false);
        }
        else
        {
            DisableMove();

        }

        //Attack 
        if (attack == true)
        {
            anim.SetBool("Attack", true);
        }
        if (attack == false)
        {
            anim.SetBool("Attack", false);
        }
        else
        {
            DisableMove();

        }

        //Backwards
        if (backwards == true)
        {
            anim.SetBool("Backwards", true);
          
        }
        if (backwards == false)
        {
            anim.SetBool("Backwards", false);
        }

        else
        {
            DisableMove();
        }
    }
    void DisableMove()
       {
        walk = false;
        attack = false;
        backwards = false;
        jump = false;

        }

}
