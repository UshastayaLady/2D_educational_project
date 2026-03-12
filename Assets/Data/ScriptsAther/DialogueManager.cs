using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Animator boxAnim;
    [SerializeField] private Animator startAnim;
    [SerializeField] private GameObject oknoDia;
    [SerializeField] public bool dialogueClosed = true;

    public static DialogueManager instance = null;

    public void Start()
    {
        if (instance == null)
        { instance = this; }
    }        

    //Starting a dialogue
    public void StartDialogue()
    {
        oknoDia.SetActive(true);
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);        
        dialogueClosed = false;
    }    

    //Closing the dialog box
   public void EndDialogue()
    {
        InstantiateDialogue.instance.CloseDialogue();
        boxAnim.SetBool("boxOpen", false);
        oknoDia.SetActive(false);
        dialogueClosed = true;
    }
}
