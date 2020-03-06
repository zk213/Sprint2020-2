using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo = 3;
    public Image[] bullets;
    bool crIsRunning = false;
    float regenerateSpeed = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        //StartCoroutine("RegenerateAmmo");
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
        if (crIsRunning == false)
        {
            StartCoroutine("RegenerateAmmo");
        }
    }

    IEnumerator RegenerateAmmo()
    {
        crIsRunning = true;
        yield return new WaitForSeconds(regenerateSpeed);
        if (currentAmmo < maxAmmo)
        {
            currentAmmo++;
        }

        if (currentAmmo == 3)
        {
            iTween.ScaleFrom(bullets[0].gameObject, new Vector3 (1.5f,1.5f,0f), 0.5f);
        }

        if (currentAmmo == 2)
        {
            iTween.ScaleFrom(bullets[1].gameObject, new Vector3(1.5f, 1.5f, 0f), 0.5f);
        }

        if (currentAmmo == 1)
        {
            iTween.ScaleFrom(bullets[2].gameObject, new Vector3(1.5f, 1.5f, 0f), 0.5f);
        }

        crIsRunning = false;
        if (currentAmmo != maxAmmo)
        StartCoroutine("RegenerateAmmo");

        
    }

}
