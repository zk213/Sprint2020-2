using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RematchBlink : MonoBehaviour
{

    public Text winnerText;
    public Text rematchText;
    public Text insertCoinText;
    public Text countDownText;
    public Image playerShipImage;
    public Sprite[] playerShips;
    float currentTimer;
    int winningPlayer;

    private void Start()
    {
        if (winningPlayer == 1)
        {
            winnerText.text = "PLAYER 1 DOMINATED!";
            playerShipImage.sprite = playerShips[0];
        } else if (winningPlayer == 2)
        {
            winnerText.text = "PLAYER 2 DOMINATED!";
            playerShipImage.sprite = playerShips[1];
        }
        StartCoroutine("RematchBlinking");
        StartCoroutine("InsertCoinBlinking");
        StartCoroutine("CountDownBlink");
    }
    // Update is called once per frame
    void Update()
    {
        countDownText.text = "" + currentTimer;

        if (currentTimer <= 0)
        {
            //TODO back to main menu
        }
    }

    

    IEnumerator RematchBlinking()
    {
        iTween.PunchPosition(rematchText.gameObject, new Vector3(0, -35, 5), 0.6f);
        iTween.PunchPosition(countDownText.gameObject, new Vector3(0, -35, 5), 0.9f);
        //iTween.ValueTo(rematchText.gameObject, iTween.Hash("from", 61, "to", 100, "onUpdate", "UpdateRematch", "time", 2f));
        yield return new WaitForSeconds(1f);
        StartCoroutine("RematchBlinking");
        
    }

    IEnumerator CountDownBlink()
    {
        
        yield return new WaitForSeconds(1f);
        StartCoroutine("CountDownBlink");
    }

    //void UpdateRematch(int value)
    //{
    //    rematchText.fontSize = value;
    //}

    IEnumerator InsertCoinBlinking()
    {
        insertCoinText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        insertCoinText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("InsertCoinBlinking");
    }
}
