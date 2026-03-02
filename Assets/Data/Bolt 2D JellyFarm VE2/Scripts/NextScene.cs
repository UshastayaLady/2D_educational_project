using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private int nextScene = -1;
        
    void Start()
    {
        if (nextScene == -1)
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
    public void OpenNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
