using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreP1;
    public Text scoreP2;

    // Start is called before the first frame update
    void Awake()
    {
        scoreP1.text = GameManager.scoreP1.ToString();
        scoreP2.text = GameManager.scoreP2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreP1.text = GameManager.scoreP1.ToString();
        scoreP2.text = GameManager.scoreP2.ToString();
    }
}
