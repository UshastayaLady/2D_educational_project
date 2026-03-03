using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private TeleportPlayer teleportPlayer;
    [SerializeField] private float countUp;
    private bool ferst = true;

    private void Update()
    {
        if (counter.GetCounter() % 10 == 0 && ferst)
        {
            ferst = false;
            teleportPlayer.SetSpeed(teleportPlayer.GetSpeed() + countUp);
        }
        else if (counter.GetCounter() % 10 != 0)
        {
            ferst = true;
        }
    }
}
