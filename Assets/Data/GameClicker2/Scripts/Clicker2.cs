using System;
using UnityEngine;
using UnityEngine.UI;

public class Clicker2 : MonoBehaviour
{
    private Button buttonClick;
    [SerializeField] private int price;
    public event Action<int> OnClicked;

    void Awake()
    {
        buttonClick.GetComponent<Button>();
    }
    private void OnEnable()
    {
        buttonClick.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        buttonClick.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        OnClicked?.Invoke(price);
    }
}
