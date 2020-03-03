using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pullSpeed = 1;
    public bool isFirstPlayer = true;
    public GameObject bulletPrefab;
    private Orbiter orbiter;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
    }

    // Update is called once per frame
    void Update()
    {


        if(isFirstPlayer)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                orbiter.radius += pullSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                orbiter.radius -= pullSpeed * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shoot();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                orbiter.radius += pullSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                orbiter.radius -= pullSpeed * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                shoot();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;

        var angle = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Orbiter bulletOrbiter = bullet.GetComponent<Orbiter>();
        bulletOrbiter.speed = orbiter.speed * 2;
        bulletOrbiter.moveClockwise = orbiter.moveClockwise;
    }
}
