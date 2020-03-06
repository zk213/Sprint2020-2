using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.Find("Star");
        
        Destroy(this.gameObject, 4);
        iTween.ShakePosition(star, iTween.Hash("amount", new Vector3(0.05f, 0.05f, 0.1f), "name", "starShake", "delay", 2f, "time", 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
