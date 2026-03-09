using UnityEngine;

public class PlayerButtons : MonoBehaviour
{
    [SerializeField] private KeyCode attack = KeyCode.Mouse0;
    private AttackPlayer attackPlayer;
    private void Start() 
    { 
        attackPlayer = GetComponent<AttackPlayer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(attack))
        {
            attackPlayer.Attack();
        }
    }

    public void SetKeyAttack(KeyCode attack)
    {
        this.attack = attack;
    }
    public KeyCode GetKeyAttack()
    {
        return attack;
    }
}
