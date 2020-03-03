using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int currentAmmo;
    public int maxAmmo = 10;
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
