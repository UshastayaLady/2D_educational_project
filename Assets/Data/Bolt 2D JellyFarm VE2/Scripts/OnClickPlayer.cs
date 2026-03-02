using UnityEngine;

public class OnClickPlayer : MonoBehaviour
{
    private KeyCode click = KeyCode.Mouse0;

    void Update()
    {
        if (Input.GetKeyDown(click))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.transform != null)
            {
                if(hit.transform.TryGetComponent<TeleportPlayer>(out TeleportPlayer teleportPlayer))
                {
                    Debug.Log("Попал!");
                }
            }
        }
    }
}
