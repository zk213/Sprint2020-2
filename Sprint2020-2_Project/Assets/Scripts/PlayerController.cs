using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pullSpeed = 1;
    public bool isFirstPlayer = true;
    public GameObject bulletPrefab;
    public RingGenerator ringGenerator;

    private Orbiter orbiter;
    public int ringNum;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
        changeRing(ringGenerator.numRings);
    }

    // Update is called once per frame
    void Update()
    {


        if(isFirstPlayer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //orbiter.radius += pullSpeed * Time.deltaTime;
                changeRing(ringNum + 1);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //orbiter.radius -= pullSpeed * Time.deltaTime;
                changeRing(ringNum - 1);
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
            if (Input.GetKeyDown(KeyCode.W))
            {
                //orbiter.radius += pullSpeed * Time.deltaTime;
                changeRing(ringNum + 1);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                //orbiter.radius -= pullSpeed * Time.deltaTime;
                changeRing(ringNum - 1);
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
        bulletOrbiter.radius = orbiter.radius;
        bulletOrbiter.targetRadius = orbiter.radius;
        bulletOrbiter.speed = orbiter.speed * 2;
        bulletOrbiter.moveClockwise = orbiter.moveClockwise;
        bulletOrbiter.orbit(50);
    }

    void changeRing(int newRingNum)
    {
        if(!ringGenerator.checkValidRing(newRingNum))
        {
            //Debug.LogError("Incorrect ring num.");
            return;
        }

        ringNum = newRingNum;
        orbiter.targetRadius = ringGenerator.getRadius(ringNum);
    }

}
