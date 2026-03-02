using System;
using UnityEngine;

public class InputButton : MonoBehaviour
{
    /*

    реализовать реакицю на нажатие кнопок и вывод в консоль соответствующей информаци

    - кнопка I - "Ирис"
    - кнопка F - "Фифа"
    - левая кнопка мышки - "стрельба"

    в качестве дз прислать рабочий скрипт

     */

    private KeyCode i = KeyCode.I;
    private KeyCode f = KeyCode.F;
    private KeyCode lkmMouse = KeyCode.Mouse0;

    void Update()
    {
        if (Input.GetKeyDown(i))
        {
            Debug.Log("Ирис");
        }
        if (Input.GetKeyDown(f))
        {
            Debug.Log("Фифа");
        }
        if (Input.GetKeyDown(lkmMouse))
        {
            Debug.Log("стрельба");
        }
    }
}
