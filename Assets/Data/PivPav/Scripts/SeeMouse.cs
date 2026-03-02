using UnityEngine;

public class SeeMouse : MonoBehaviour
{
    private Vector3 transformMouse;
    private Vector2 quaternionMouse;
    private float quaternion;


    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        transformMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        quaternionMouse = transformMouse - transform.position;
        quaternion = Mathf.Atan2(quaternionMouse.y, quaternionMouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, quaternion);

    }
    
}
