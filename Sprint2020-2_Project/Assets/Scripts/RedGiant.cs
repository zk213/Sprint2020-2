using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGiant : MonoBehaviour
{
    public GameObject flarePrefab;

    private float flareCooldown;
    private float flareTimer;
    private bool useFlare;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = transform.localScale * LevelManager.Instance.getRoundType().StarDiameter;
        flareCooldown = LevelManager.Instance.getRoundType().flareFrequency;
        useFlare = LevelManager.Instance.getRoundType().useFlare;
    }


    private void Update()
    {
        if(useFlare && flareTimer > flareCooldown)
        {
            flareTimer = 0;
            shootFlare();
        }
        flareTimer += Time.deltaTime;
    }

    private void shootFlare()
    {
        GameObject flare = Instantiate(flarePrefab);

        float angle = Random.Range(0, 360);
        flare.transform.localScale = transform.localScale;
        flare.transform.Rotate(0, 0, angle);
        flare.transform.position = flare.transform.up * transform.localScale.x * 0.5f;
    }
}
