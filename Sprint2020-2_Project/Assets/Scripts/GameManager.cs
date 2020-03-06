using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd = false;
    public static int scoreP1 = 0;
    public static int scoreP2 = 0;

    private const int winScore = 100;

    public static IEnumerator restart()
    {
        yield return new WaitForSeconds(1.5f);

        if(scoreP1 == winScore || scoreP2 == winScore)
        {
            FindObjectOfType<LevelChanger>().FadeToLevel(2);
        }
        else
        {
            LevelManager.Instance.goToNextRound();
        }
    }

    public static void rematch()
    {
        gameEnd = false;
        scoreP1 = 0;
        scoreP2 = 0;
    }
}
