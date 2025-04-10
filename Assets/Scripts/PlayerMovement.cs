using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour{
    public CharacterController controller ;
    public float mvtSpeed = 10f;
    public float gravity = -9.81f *2;
    public float jumpHight = 3f;
    public Vector3 velocity ;
    public Transform groundCheck ;
    public float groundDistance = 0.4f;
    public LayerMask groundMask ;
    public Boolean onGround ;
    void Update(){
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Check ground collision (using physics because we can't use the collider with characterController) and reset velocity if so
        onGround = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(onGround && velocity.y < 0){
            velocity.y = -2f;
            
        }
        
        //moving to the sides and the front/back
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * z + transform.right * x ;

        controller.Move(move * mvtSpeed * Time.deltaTime);
        
        //jump
        if(Input.GetButtonDown("Jump") && onGround){
            velocity.y = MathF.Sqrt(jumpHight * gravity * -2f);
        }
        //applying gravity
        
        velocity.y += gravity * Time.deltaTime ;
        controller.Move(velocity*Time.deltaTime);

    }
    //DEBUG : drawing the groundCheck with different colors 
    private void OnDrawGizmos(){
        if (groundCheck != null)
        {
            Gizmos.color = onGround ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}
