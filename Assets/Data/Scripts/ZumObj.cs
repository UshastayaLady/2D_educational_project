using UnityEngine;

public class ZumObj : MonoBehaviour
{
    public Transform target;          // объект, к которому зумимся
    public float zoomSpeed = 5f;      // скорость зума
    public float minDistance = 1f;    // минимальная дистанция до объекта
    public float maxDistance = 20f;   // максимальная дистанция

    float distance;

    void Start()
    {
        if (!target) return;
        distance = Vector3.Distance(transform.position, target.position);
    }

    void Update()
    {
        if (!target) return;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) < 0.0001f) return;

        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // направление от объекта к камере
        Vector3 dir = (transform.position - target.position).normalized;

        // ставим камеру на нужную дистанцию и смотрим на объект
        transform.position = target.position + dir * distance;
        transform.LookAt(target);
    }
}
