using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //velocity and turning speed of the character
    public float velocity = 15;
    public float turnSpeed = 10;

    public GameObject gb;
    Animator animator;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform cam;



    // Use this for initialization
    void Start () {
        animator = gb.GetComponent<Animator>();
        cam = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
        if(Mathf.Abs(input.x)<1 && Mathf.Abs(input.y) < 1){
            animator.SetBool("isWalking", false);
            return;
        }
        CalculateDirection();
        Rotate();
        Move();
    }

    //A method to make the character move
    void Move()
    {
        Rigidbody rigidbody = gb.GetComponent<Rigidbody>();
        animator.SetBool("isWalking", true);
        //transform.position += transform.forward * velocity * Time.deltaTime;   
        rigidbody.MovePosition(transform.position + transform.forward * velocity * Time.deltaTime);
        
    }

    //a method to get the user input
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    //calculate the direction of the character.
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    //rotate the character
    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,turnSpeed*Time.deltaTime);
       
    }
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = gb.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

    }

    private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(collision.gameObject.tag=="InteractableItem")
                Destroy(collision.gameObject);

        }
    }
}
