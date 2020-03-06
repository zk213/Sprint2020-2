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
    public int winningPlayer;
    [SerializeField]
    private float countDownTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Start()
    {
        if (winningPlayer == 1)
        {
            winnerText.text = "PLAYER 1 DOMINATED!";
            winnerText.color = new Color(1, 0.5f, 0f);
            playerShipImage.sprite = playerShips[0];
        } else if (winningPlayer == 2)
        {
            winnerText.text = "PLAYER 2 DOMINATED!";
            winnerText.color = Color.blue;
            playerShipImage.sprite = playerShips[1];
        }
        timer = countDownTimer;
        StartCoroutine("RematchBlinking");
        StartCoroutine("InsertCoinBlinking");
        StartCoroutine("CountDownBlink");
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            countDownText.text = timer.ToString("0");
            Mathf.RoundToInt(timer);
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            countDownText.text = "0";
            timer = 0.0f;

            Debug.Log("Hello");
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
