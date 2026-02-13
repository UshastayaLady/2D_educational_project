using UnityEngine;

public class PlayerTriggerListener : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var zone = collision.GetComponent<ITriggerZone>();
        zone?.OnEnter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var zone = collision.GetComponent<ITriggerZone>();
        zone?.OnExit();
    }
}
