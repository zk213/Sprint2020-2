using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGiant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = transform.localScale * LevelManager.Instance.getRoundType().StarDiameter;
    }
}
