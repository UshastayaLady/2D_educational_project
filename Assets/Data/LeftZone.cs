using Unity.VisualScripting;
using UnityEngine;

public class LeftZone : MonoBehaviour, ITriggerZone
{
    /*

    Создать на сцене 2 тригерных зоны под названием <LEFT> в которой будет находится куб и <RIGHT> в которой находится круг, 
    Создать отдельный скрипт на персонаже который будет реагировать на эти зоны

    - при попадании в <LEFT> вы запускаете вращение куба вокруг своей оси,
    - при попадании в <RIGHT> вы запускаете процес увеличения круга в размерах

    */
    
    [SerializeField] private float speed;
    [SerializeField] private Transform transformTerget;
    private float speedNow;
    Vector2 newRotate;

    private void Update()
    {        
        if (Mathf.Abs(transformTerget.rotation.x) > 360 )
        {
            speedNow *= -1;
        }        
        newRotate = new Vector2(transformTerget.rotation.x, transformTerget.rotation.x + speedNow * Time.deltaTime);
        transformTerget.Rotate(newRotate);
    }

    public void OnEnter()
    {
        speedNow = speed;
    }

    public void OnExit()
    {
        speedNow = 0;
    }
}
