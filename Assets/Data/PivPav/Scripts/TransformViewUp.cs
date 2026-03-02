using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TransformViewUp : MonoBehaviour
{
    [SerializeField] private float speed;
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private Rigidbody2D rigidbody;
    private float dictionaryX;
    private float dictionaryY;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        dictionaryX = Input.GetAxis(Horizontal);
        dictionaryY = Input.GetAxis(Vertical);

        transform.position = new Vector3(transform.position.x + speed * dictionaryX * Time.deltaTime, transform.position.y + speed * dictionaryY * Time.deltaTime, 0);
    }
}
