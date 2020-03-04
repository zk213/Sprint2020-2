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
        SceneManager.LoadScene(0);
    }
}
