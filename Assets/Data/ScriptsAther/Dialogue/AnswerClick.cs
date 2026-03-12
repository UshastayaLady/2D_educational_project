using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerClick : MonoBehaviour
{
    [SerializeField] private Button thisButton;
    private int idAnswer;
    public static event Action<int> answerClick;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnAnswerClick);
    }

    private void OnAnswerClick()
    {
        answerClick?.Invoke(idAnswer);
    }

    public void SetIdAnswer(int idNumber)
    {
        idAnswer = idNumber;
    }
}
