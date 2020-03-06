using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPress : MonoBehaviour
{
    public int sceneIndexToLoad;
    public bool resetLevels = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(resetLevels)
            {
                LevelManager.roundTypeIndex = 0;
            }

            FindObjectOfType<AudioManager>().Play("ShootingBullet", this.gameObject);
            FindObjectOfType<LevelChanger>().FadeToLevel(sceneIndexToLoad);
        }
    }

}
