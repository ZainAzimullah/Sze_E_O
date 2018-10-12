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
    void OnCollisionEnter(Collision collision)
    {
        collision.impulse.Set(0, 0, 0);
        Rigidbody rb = gb.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        

    }

    private void OnCollisionStay(Collision collision)
    {
        collision.impulse.Set(0, 0, 0);
        Rigidbody rigidbody = gb.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.down * 5000 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneTransitionManager sceneTransitionManager = SceneTransitionManager.Instance;
            int currentLevel = LevelManager.Instance.currentLevel;
            Tracker tracker = PlayerManager.Instance.GetTracker(currentLevel);
            if (collision.gameObject.tag == "Dialog")
            {
                tracker.playerPos = gb.transform.position;
                tracker.playerAngle = gb.transform.eulerAngles;
                tracker.camAngle = cam.eulerAngles;
                tracker.camPos = cam.position;
                sceneTransitionManager.LoadScene(SceneEnum.ConsultGregDialog);
            }
        }
            
        
    }

    void SetTracker(Tracker tracker)
    {
        tracker.playerPos = gb.transform.position;
        tracker.playerAngle = gb.transform.eulerAngles;
        tracker.camAngle = cam.eulerAngles;
        tracker.camPos = cam.position;
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tracker tracker = PlayerManager.Instance.GetTracker(LevelManager.Instance.currentLevel);
            SetTracker(tracker);
            GameLogicManager.Instance.Interaction(collision);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector2.up, 0.1f);
    }
}
