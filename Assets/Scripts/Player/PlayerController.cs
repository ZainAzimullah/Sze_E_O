using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerManager playerManager=PlayerManager.Instance;
        Tracker tracker = playerManager.GetTracker(LevelManager.Instance.currentLevel);

        //Record the player position and where the player faces to if it's the first time the player enter the layer
        //Otherwise load the values when last time the player exits the layer.
        if (tracker.playerPos == Vector3.zero)
        {
            
            tracker.playerPos=(Vector3)gb.transform.position;
        }
        else
        {
            gb.transform.position = tracker.playerPos;
        }

        if (tracker.playerAngle == Vector3.zero)
        {
            tracker.playerAngle = gb.transform.eulerAngles;
        }
        else
        {
            gb.transform.eulerAngles = tracker.playerAngle;
        }
      
    }
	
	// Update is called once per frame
	void Update () {
        //player falls down if the player is above the ground 
        if (!IsGrounded())
        {
            Rigidbody rigidbody = gb.GetComponent<Rigidbody>();
            rigidbody.MovePosition(transform.position + Vector3.down * 7 *Time.deltaTime);
        }
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
    
    //Stop player rotating and being bounce back by the other object when first collide on the object.
    void OnCollisionEnter(Collision collision)
    {
        collision.impulse.Set(0, 0, 0);
        Rigidbody rb = gb.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    //This method is used to deal with the situation where the player keeps bouncing on the object.
    private void OnCollisionStay(Collision collision)
    {
        collision.impulse.Set(0, 0, 0);
        Rigidbody rigidbody = gb.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.down * 5000 * Time.deltaTime);
        //Mainly used to interact with moving npc.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneTransitionManager sceneTransitionManager = SceneTransitionManager.Instance;
            int currentLevel = LevelManager.Instance.currentLevel;
            Tracker tracker = PlayerManager.Instance.GetTracker(currentLevel);
            if (collision.gameObject.tag != "Untagged")
            {
                // Fix for unknown camera bug in level 1
                if ((LevelManager.Instance.currentLevel != 1) && (LevelManager.Instance.currentLevel != 0))
                {
                    tracker.playerPos = gb.transform.position;
                    tracker.playerAngle = gb.transform.eulerAngles;
                    tracker.camAngle = cam.eulerAngles;
                    tracker.camPos = cam.position;
                }
                GameLogicManager.Instance.Interaction(collision.collider);
            }
        }
            
        
    }

    //set the trackers
    void SetTracker(Tracker tracker)
    {
        tracker.playerPos = gb.transform.position;
        tracker.playerAngle = gb.transform.eulerAngles;
        tracker.camAngle = cam.eulerAngles;
        tracker.camPos = cam.position;
    }

    //When player enters the trigger
    private void OnTriggerStay(Collider collision)
    {
        //Player interact with the object when space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tracker tracker = PlayerManager.Instance.GetTracker(LevelManager.Instance.currentLevel);
            // Fix for unknown camera bug in level 1
            if ((LevelManager.Instance.currentLevel != 1) && (LevelManager.Instance.currentLevel != 0))
            {
                SetTracker(tracker);
            }
            GameLogicManager.Instance.Interaction(collision);
        }
    }

    //Check whether the player is on the ground
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector2.up, 0.1f);
    }
}
