using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo = 3;
    public Image[] bullets;
    float regenerateSpeed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        StartCoroutine("RegenerateAmmo");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo == 3)
        {
            bullets[0].fillAmount = 1;
            bullets[1].fillAmount = 1;
            bullets[2].fillAmount = 1;
        }

        if (currentAmmo == 2)
        {
            bullets[0].fillAmount = 0;
            bullets[1].fillAmount = 1;
            bullets[2].fillAmount = 1;
        }

        if (currentAmmo == 1)
        {
            bullets[0].fillAmount = 0;
            bullets[1].fillAmount = 0;
            bullets[2].fillAmount = 1;
        }

        if (currentAmmo == 0)
        {
            bullets[0].fillAmount = 0;
            bullets[1].fillAmount = 0;
            bullets[2].fillAmount = 0;
        }



    }

    public void consumeAmmo()
    {
        currentAmmo--;
    }

    IEnumerator RegenerateAmmo()
    {
        yield return new WaitForSeconds(regenerateSpeed);
        if (currentAmmo < maxAmmo)
        {
            currentAmmo++;
        }
        StartCoroutine("RegenerateAmmo");
    }

}
