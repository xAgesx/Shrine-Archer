using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject Arrow;
    public float shootForce = 50f;
    public Camera mainCamera;
    int arrowsInScene = 0;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot(){
        Vector3 shootDirection = mainCamera.transform.forward;
        Transform shooterTransform = GetComponentInParent<Transform>();
        Quaternion rotationOffset = Quaternion.Euler(-90, 0, 0); // Adjust as needed
        GameObject spawnedArrow = Instantiate(
            Arrow,
            shooterTransform.position,
            Quaternion.LookRotation(shootDirection) * rotationOffset
        );
        arrowsInScene ++;
        // Apply velocity to shoot the arrow
        Rigidbody rb = spawnedArrow.GetComponent<Rigidbody>();
        if (rb != null){
            rb.velocity = shootDirection * shootForce;
        }
        if(arrowsInScene > 5){
            GameObject oldArrow = GameObject.FindGameObjectWithTag("Arrow");
            Destroy(oldArrow);
        }
    }
}
