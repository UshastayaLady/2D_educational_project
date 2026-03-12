using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private InstantiateDialogue iInstantiateDialogue;

    private void Awake()
    {
        iInstantiateDialogue = FindAnyObjectByType<InstantiateDialogue>();
    }

    private void OnEnable()
    {
        iInstantiateDialogue.Finish += CloseWindos;
    }
    public void OpenWindos(TextAsset textAsset)
    {
        iInstantiateDialogue.gameObject.SetActive(true);
        iInstantiateDialogue.StartDialogue(textAsset);
    }

    private void CloseWindos()
    {
        iInstantiateDialogue.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        iInstantiateDialogue.Finish -= CloseWindos;
    }
}
