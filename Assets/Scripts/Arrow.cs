using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour{

    Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(){
        //Stop arrow mvt
        rb.velocity = new Vector3(0,0,0) ;
        rb.isKinematic = true ;
        
        Debug.Log("hit");
    }
}
