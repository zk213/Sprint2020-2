using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float pullSpeed = 1;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public RingGenerator ringGenerator;
    Ammo ammoScript;

    private Orbiter orbiter;
    public int ringNum;
    private float timeSinceLastRingChange;

    public bool isFirstPlayer = true;
    public bool isPC = true;

    // Start is called before the first frame update
    void Start()
    {
        orbiter = GetComponent<Orbiter>();
        ammoScript = GetComponent<Ammo>();
        changeRing(ringGenerator.numRings);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameEnd)
        {
            return;
        }

        if(isPC)
        {
            checkControlsPC();
        }
        else
        {
            checkControlsArcade();
        }

        timeSinceLastRingChange += Time.deltaTime;
    }

    void checkControlsPC()
    {
        if (isFirstPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                shoot();
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                shoot();
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }
        }
    }
    void checkControlsArcade()
    {
        if (isFirstPlayer)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                shoot();
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                shoot();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                orbiter.moveClockwise = !orbiter.moveClockwise;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (transform.position.y >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum - 1);
                }
                else
                {
                    changeRing(ringNum + 1);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (transform.position.x >= 0)
                {
                    changeRing(ringNum + 1);
                }
                else
                {
                    changeRing(ringNum - 1);
                }
                return;
            }
        }
    }

    void shoot()
    {
        if (ammoScript.currentAmmo > 0) { 
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
        ammoScript.consumeAmmo();
        }
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

        timeSinceLastRingChange = 0;
    }

    public void die()
    {
        if (isFirstPlayer)
        {
            GameManager.scoreP2++;
        }
        else
        {
            GameManager.scoreP1++;
        }
        GameManager.gameEnd = true;
        Destroy(gameObject.transform.GetChild(0).gameObject);
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;

        StartCoroutine(GameManager.restart());
    }

    public float getTimeSinceLastRingChange()
    {
        return timeSinceLastRingChange;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController otherPlayer = collision.gameObject.GetComponent<PlayerController>();
            if(otherPlayer.getTimeSinceLastRingChange() > 0.1f)
            {
                //If they are on the same ring and collide, their directions are reversed
                orbiter.moveClockwise = !orbiter.moveClockwise;
                return;
            }
            if(otherPlayer.getTimeSinceLastRingChange() < timeSinceLastRingChange)
            {
                die();
            }
        }
    }

}
