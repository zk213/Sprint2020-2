using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd = false;
    public static int scoreP1 = 0;
    public static int scoreP2 = 0;
    public static int lastWinner = 1;

    private const int winScore = 1500;

    public static IEnumerator restart()
    {
        yield return new WaitForSeconds(1.5f);

        if(scoreP1 == winScore || scoreP2 == winScore)
        {
            if(scoreP1 > scoreP2)
            {
                lastWinner = 1;
            }
            else if(scoreP1 < scoreP2)
            {
                lastWinner = 2;
            }
            else
            {
                lastWinner = 0; 
            }

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
        LevelManager.currentRound = 0;
    }
}
