using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PoolObject))]
public class ViewDialogue : MonoBehaviour
{
    [SerializeField] private GameObject Window;

    [SerializeField] private Text nodeText;
    [SerializeField] private RectTransform panelAnswer;

    private PoolObject poolObject;

    private void Awake()
    {
        poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable()
    {
        InstantiateDialogue.NpsText += WriteText;
    }
    private void WriteText(string npsText)
    {
        nodeText.text = npsText;
        InstantiateDialogue.Answer += WriteAnswer;
    }

    private void WriteAnswer(string answer, int idButton)
    {
        FindPool buttonAnswer = poolObject.GetObgectInPool();
        try
        {            
            buttonAnswer.GetComponentInChildren<Text>().text = answer;            
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("NullReferenceException в buttonAnswer отсутствует компонент Text: " + ex.Message);
        }

        try
        {
            buttonAnswer.GetComponent<AnswerClick>().SetIdAnswer(idButton);
            buttonAnswer.transform.SetParent(panelAnswer, false);
            buttonAnswer.gameObject.SetActive(true);
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("NullReferenceException в buttonAnswer отсутствует компонент AnswerClick: " + ex.Message);
        }        
        
    }

    private void OnDisable()
    {
        InstantiateDialogue.NpsText -= WriteText;
        InstantiateDialogue.Answer -= WriteAnswer;
    }
}
