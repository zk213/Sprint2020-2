using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPress : MonoBehaviour
{
    public int sceneIndexToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            FindObjectOfType<AudioManager>().Play("ShootingBullet", this.gameObject);
            FindObjectOfType<LevelChanger>().FadeToLevel(sceneIndexToLoad);
        }
    }

}
