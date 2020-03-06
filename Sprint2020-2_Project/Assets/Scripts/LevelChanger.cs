using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;
    private bool levelChanging = false;

    public void FadeToLevel(int levelIndex)
    {
        if(!levelChanging)
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("Swipe");
            levelChanging = true;
        }
    }

    public void OnFadeComplete()
    {
        GameManager.gameEnd = false;
        SceneManager.LoadScene(levelToLoad);
    }
}