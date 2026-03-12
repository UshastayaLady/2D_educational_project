using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;


public class InstantiateDialogue : MonoBehaviour
{
    #region variables

    private ReadXmlDialogue xmlDialogue;

    [SerializeField] private GameObject Window;
        
    [SerializeField] private Text nodeText;


    [SerializeField] private Text firstAnswer;
    [SerializeField] private Text secondAnswer;
    [SerializeField] private Text thirdAnswer;
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;

    public static event Action<string> NpsText;
    public static event Action<string, int> Answer;
    public static event Action finish;
    public static event Action finishNextDialogue;

    private TextAsset ta;

    private int currentNode = 0;
    private int butClicked;
    #endregion

    #region 
    void Start()
    {
        xmlDialogue = GetComponent<ReadXmlDialogue>();
        secondButton.enabled = false;
        thirdButton.enabled = false;
       
        firstButton.onClick.AddListener(but1); // 1 вариант ответа
        secondButton.onClick.AddListener(but2); // 2 вариант ответа
        thirdButton.onClick.AddListener(but3); // 3 вариант ответа
        
    }

    public void StartDialogue()
    {
        if (ta!=null)
        {
            firstStart(); // показ 1 нода
        }                   
    }

    #region // Buttons Кнопки для переходы на ответы в зависимости от выбора игрока
    private void but1()
    {
        butClicked = 0;
        StartCoroutine(AnswerClicked(0));
    }
    private void but2()
    {
        butClicked = 1;
        StartCoroutine(AnswerClicked(1));
    }
    private void but3()
    {
        butClicked = 2;
        StartCoroutine (AnswerClicked(2));
    }
    #endregion
        
    private void firstStart()
    {
        xmlDialogue = null;
        xmlDialogue = ReadXmlDialogue.Load(ta);
        currentNode = 0;
        WriteText();
    }    
   
    private void WriteText()
    {
        deleteDialogue(); //скидываем текст ответа каждый раз перед началом печати нового ответа НПС
        nodeText.text = xmlDialogue.nodes[currentNode].npcText;
        NpsText?.Invoke(xmlDialogue.nodes[currentNode].npcText);
        
        
        //firstAnswer.text = xmlDialogue.nodes[currentNode].answers[0].text;     //первый ответ будет всегда
                                                                            
        //if (xmlDialogue.nodes[currentNode].answers.Length >= 2)                //если ответов два
        //{
        //    secondButton.enabled = true;
        //    secondAnswer.text = xmlDialogue.nodes[currentNode].answers[1].text;    //показываем 
        //}
        //else
        //{
        //    secondButton.enabled = false;                                       //иначе скрываем
        //    secondAnswer.text = "";
        //}

        //if (xmlDialogue.nodes[currentNode].answers.Length == 3) // если ответа 3
        //{
        //    thirdButton.enabled = true;
        //    thirdAnswer.text = xmlDialogue.nodes[currentNode].answers[2].text;
        //}
        //else
        //{
        //    thirdButton.enabled = false;
        //    thirdAnswer.text = "";
        //}

        for (int j = 0; j < xmlDialogue.nodes[currentNode].answers.Length; j++)
        {
            Answer?.Invoke(xmlDialogue.nodes[currentNode].answers[j].text, j);
            // события на добавление ответа
        }
    }
    
    #endregion  

    private IEnumerator AnswerClicked(int numberOfButton)
    {
        

        if (!DialogueManager.instance.dialogueClosed)
        {
            if (xmlDialogue.nodes[currentNode].answers[numberOfButton].endRestart == "true")
            {
                // метод закрытия окна
                finish?.Invoke();
                yield return new WaitForSeconds(2f);
            }
            else if (xmlDialogue.nodes[currentNode].answers[numberOfButton].endNextDialogue == "true")
            {
                // метод закрытия окна переход на следющий диалог
                finishNextDialogue?.Invoke();
            }
            else
            {
                currentNode = xmlDialogue.nodes[currentNode].answers[numberOfButton].nextNode;
                WriteText();
            }
        }
    }  

    //окончание диалога
    public void CloseDialogue()
    {

        if (xmlDialogue != null)
        {
            xmlDialogue = null;
        }
        deleteDialogue();
        currentNode = 0; // Начинаем с первого узла
    }

    //очистка диалогового окна
    private void deleteDialogue()
    {
        secondButton.enabled = false;
        thirdButton.enabled = false;
        nodeText.text = ""; 
        firstAnswer.text = "";
        secondAnswer.text = "";
        thirdAnswer.text = "";
    }    

}