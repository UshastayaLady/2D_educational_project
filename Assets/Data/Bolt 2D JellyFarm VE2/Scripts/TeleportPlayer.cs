using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private float xMin, xMax;
    [SerializeField] private float yMin, yMax;
    [SerializeField] private float speed;
    private Vector3 newTransform;
    private SpriteRenderer spriteRenderer;
    private float directionX;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        newTransform = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
    }


    void Update()
    {
        RandomTeleport();
        LookAtPlayer();
    }

    private void RandomTeleport()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTransform, speed * Time.deltaTime);
        
        if (transform.position == newTransform) 
        {
            newTransform = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        }
    }

    private void LookAtPlayer()
    {
        directionX = transform.position.x - newTransform.x;
        if (directionX > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
