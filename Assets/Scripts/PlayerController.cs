using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public float laneDistance =4;

    public float jumpForce;
    public float Gravity = -20;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(forwardSpeed);
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;

       if(controller.isGrounded){
         if(Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();
        }
       }

       
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane ==3)
               desiredLane = 2;
        }         
      
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane ==-1)
               desiredLane = 0;
        } 

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }      

        transform.position = targetPosition;
        controller.center = controller.center;
       

    }
    private void FixedUpdate(){
        controller.Move(direction*Time.deltaTime);
    }

    private void Jump(){
        direction.y = jumpForce;
    }
}