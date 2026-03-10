using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


public class PlayerHorizantal : MonoBehaviour
{
    [SerializeField] private const string Horizantal = nameof (Horizontal);
    [SerializeField] private float speed;
    private float directionX;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        directionX = Input.GetAxis(Horizantal);
        if (directionX != 0)
        {
            transform.position = new Vector3(transform.position.x + directionX * speed * Time.deltaTime, transform.position.y);
        }
    }
}
