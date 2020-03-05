using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameEnd = false;
    public static int scoreP1 = 0;
    public static int scoreP2 = 0;

    public static IEnumerator restart()
    {
        yield return new WaitForSeconds(1.5f);
        gameEnd = false;
        LevelManager.Instance.goToNextRound();
        SceneManager.LoadScene(0);
    }

    public static void rematch()
    {
        gameEnd = false;
        scoreP1 = 0;
        scoreP2 = 0;
        //LevelManager.currentRound = 0;
    }
}
