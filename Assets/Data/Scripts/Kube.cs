using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Kube : MonoBehaviour
{
    /*

    Создать квадрат, повесить на него скрипт <Kube>  и реализовать такие возможности:

    - при нажатии кнопок A или D (а также стрелок влево-вправо) - куб вращается по часовой или против часовой стрелки;
    - при нажатии кнопок W или S (а также стрелок вверх-вниз) - куб увеличивается или уменьшается в размерах;

    В качестве DZ прислать только скрипт <Kube>

     */
    [SerializeField] private float speedRotate = 100;
    [SerializeField] private float speedScale = 100;
    private float directionOX;
    private float directionOY;
    private float minScale = 0.1f;

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        ScaleObject();
    }

    private void RotateObject()
    {
        directionOX = Input.GetAxis("Horizontal");
        Vector2 newRoTate = new Vector2(transform.rotation.x, directionOX * speedRotate * Time.deltaTime);
        transform.Rotate(newRoTate);
    }
    private void ScaleObject()
    {
        directionOY = Input.GetAxis("Vertical");
        Vector2 newScale = new Vector2(transform.localScale.x + directionOY * speedScale * Time.deltaTime, transform.localScale.y + directionOY * speedScale * Time.deltaTime);
        if (newScale.x > minScale)
        {
            transform.localScale = newScale;
        }
        
    }
}
