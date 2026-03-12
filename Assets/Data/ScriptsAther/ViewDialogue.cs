using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PoolObject))]
public class ViewDialogue : MonoBehaviour
{
    [SerializeField] private Text nodeText;
    [SerializeField] private RectTransform textContainer;

    [SerializeField] private ScrollRect textScrollRect;
    [SerializeField] private RectTransform panelAnswer;

   
    [SerializeField] private AnswerClick answerClick;

    private InstantiateDialogue instantiateDialogue;
    private PoolObject poolObject;

    private void Awake()
    {
        poolObject = GetComponent<PoolObject>();
        instantiateDialogue = GetComponent<InstantiateDialogue>();
    }

    private void OnEnable()
    {
        instantiateDialogue.NpsText += WriteText;        
        instantiateDialogue.Answer += WriteAnswer;
        answerClick.answerClick += DelAnswer;
    }
    private void WriteText(string npsText)
    {
        nodeText.text = npsText;
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
            //buttonAnswer.transform.SetParent(panelAnswer, false);
            buttonAnswer.gameObject.SetActive(true);
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError("NullReferenceException в buttonAnswer отсутствует компонент AnswerClick: " + ex.Message);
        }  
    }

    private void DelAnswer(int idButton)
    {
        FindPool[] buttons = panelAnswer.GetComponentsInChildren<FindPool>();
        for (int i = 0; i < buttons.Length; i++)
        {
            try
            {
                buttons[i].GetComponentInChildren<Text>().text = "";
            }
            catch (NullReferenceException ex)
            {
                Debug.LogError("NullReferenceException в buttonAnswer отсутствует компонент Text: " + ex.Message);
            }
            poolObject.PutObgectInPool(buttons[i]);
        }

    }

    private void OnDisable()
    {
        instantiateDialogue.NpsText -= WriteText;
        instantiateDialogue.Answer -= WriteAnswer;
        answerClick.answerClick -= DelAnswer;
    }
}
