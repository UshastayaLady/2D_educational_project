using UnityEngine;

public class rotObj : MonoBehaviour
{
    float rotSpeed = 20;
    
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);

        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.forward, -rotY);

        //float rotZ = Input.GetAxis("Mouse Z") * rotSpeed * Mathf.Deg2Rad;

        //transform.RotateAround(Vector3.forward, -rotZ);
    }
}