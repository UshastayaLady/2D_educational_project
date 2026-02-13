using UnityEngine;

public class RightZone : MonoBehaviour, ITriggerZone
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

    private void Update()
    {
        if (Mathf.Abs(transformTerget.localScale.x) > 3)
        {
            speedNow *= -1;
        }
        float newScale = transformTerget.localScale.x + speedNow * Time.deltaTime;
        Vector2 newScaleSprite = new Vector2(newScale, newScale);
        transformTerget.localScale = newScaleSprite;
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
