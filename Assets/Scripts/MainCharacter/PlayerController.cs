﻿using System.Collections;
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
    private void Awake()
    {
        //PlayerManager playerManager = PlayerManager.Instance;
        //Debug.Log(playerManager == null);
        //Debug.Log("PlayerController");
    }

    // Use this for initialization
    void Start () {
        animator = gb.GetComponent<Animator>();
        cam = Camera.main.transform;
        PlayerManager playerManager=PlayerManager.Instance;
        //Debug.Log(playerManager==null);
        if (playerManager.getPlayer() == Vector3.zero)
        {
            
            playerManager.setPlayer((Vector3)gb.transform.position);
        }
        else
        {
            gb.transform.position = playerManager.getPlayer();
        }

        if (playerManager.faceTo == Vector3.zero)
        {
            playerManager.faceTo = gb.transform.eulerAngles;
        }
        else
        {
            gb.transform.eulerAngles = playerManager.faceTo;
        }
        
        /*gb.transform.position = playerManager.playerPosition.position;
        gb.transform.rotation = playerManager.playerPosition.rotation;*/
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
        collision.impulse.Set(0, 0, 0);
        Rigidbody rb = gb.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        

    }

    private void OnCollisionStay(Collision collision)
    {
        collision.impulse.Set(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneTransitionManager sceneTransitionManager = SceneTransitionManager.GetInstance();
            if (collision.gameObject.tag == "Dialog")
            {
                /*Debug.Log("Dialog");
                SceneManager.LoadScene("Gameplay");*/
                //PlayerManager.Instance.playerPosition = gb.transform;
                sceneTransitionManager.LoadScene(SceneEnum.DIALOGUE);
            }
        }
            
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (collision.gameObject.tag == "Elevator")
            {
                Debug.Log("Elevator");
                
            }
            if (collision.gameObject.tag == "Dialog")
                Debug.Log("Dialog");
            if (collision.gameObject.tag == "Computer")
                Debug.Log("Computer");

        }*/
    }

    private void OnTriggerStay(Collider collision)
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneTransitionManager sceneTransitionManager = SceneTransitionManager.GetInstance();
            if (collision.gameObject.tag == "Elevator")
            {
                /*Debug.Log("Elevator");
                SceneManager.LoadScene("Gameplay");*/
                //PlayerManager.Instance.playerPosition = gb.transform;
               
                sceneTransitionManager.LoadScene(SceneEnum.ELEVATOR);

            }
            if (collision.gameObject.tag == "Dialog")
            {
                /*Debug.Log("Dialog");
                SceneManager.LoadScene("Gameplay");*/
                //PlayerManager.Instance.playerPosition = gb.transform;
                sceneTransitionManager.LoadScene(SceneEnum.DIALOGUE);
            }              
            if (collision.gameObject.tag == "Computer")
            {
                /*Debug.Log("Computer");
                SceneManager.LoadScene("Gameplay");*/


                //PlayerManager.Instance.playerPosition = gb.transform;
                PlayerManager.Instance.setPlayer(gb.transform.position);
                PlayerManager.Instance.faceTo = gb.transform.eulerAngles;
                //Debug.Log(PlayerManager.Instance.playerPosition.position);
                sceneTransitionManager.LoadScene(SceneEnum.BOOLEAN_GAME);

            }

                

        }
    }
}
