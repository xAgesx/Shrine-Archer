using UnityEngine;

public class MouseLook : MonoBehaviour{
    public Transform player;
    public float mouseSensitivity = 300f;
    public float xRotation = 0f;


    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update(){
        //get mouse x and y every frame 
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        //xRotation is used so I can clamp (limit) the rotation instead of using Rotate()
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        player.Rotate(0, mouseX, 0);
        //
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

    }
}
