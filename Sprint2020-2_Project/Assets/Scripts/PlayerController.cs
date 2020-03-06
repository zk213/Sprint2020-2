using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float pullSpeed = 1;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public Text player1Score;
    public Text player2Score;
    public RingGenerator ringGenerator;
    Ammo ammoScript;
    GameObject cameraObject;
    private Orbiter orbiter;
    public int ringNum;
    private float ringChangeCooldown = 0.1f;
    public float timeSinceLastRingChange;

    public bool isFirstPlayer = true;
    public bool isPC = true;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        orbiter = GetComponent<Orbiter>();
        ammoScript = GetComponent<Ammo>();
        changeRing(ringGenerator.numRings);
        orbiter.speed = LevelManager.Instance.getRoundType().playerSpeed;

        if(!orbiter.moveClockwise)
        {
            transform.Rotate(0, 0, 180);
        }
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
                changeDirection();
            }

            if (timeSinceLastRingChange < ringChangeCooldown)
            {
                return;
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
                changeDirection();
            }

            if (timeSinceLastRingChange < ringChangeCooldown)
            {
                return;
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
                changeDirection();
            }

            if (timeSinceLastRingChange < ringChangeCooldown)
            {
                return;
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
                changeDirection();
            }

            if(timeSinceLastRingChange < ringChangeCooldown)
            {
                return;
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

    public void changeDirection()
    {
        orbiter.moveClockwise = !orbiter.moveClockwise;
        transform.Rotate(0, 0, 180);
    }


    void shoot()
    {
        if (ammoScript.currentAmmo > 0)
        {
            FindObjectOfType<AudioManager>().Play("ShootingBullet", this.gameObject);
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
        
        GameManager.gameEnd = true;
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        FindObjectOfType<AudioManager>().Play("PlayerExplosionMiddle", this.gameObject);

        StartCoroutine(GameManager.restart());

        if (isFirstPlayer)
        {
            iTween.ValueTo(gameObject, iTween.Hash("name", "Player2FontPunch", "from", 70, "to", 30, "onUpdate", "UpdateFontSize2", "time", 1f));
            iTween.ValueTo(gameObject, iTween.Hash("from", GameManager.scoreP2, "to", GameManager.scoreP2 + 100, "onUpdate", "UpdatePlayerScore2", "time", 0.5f));
        }
        else
        {
            iTween.ValueTo(gameObject, iTween.Hash("name", "Player1FontPunch", "from", 70, "to", 30, "onUpdate", "UpdateFontSize1", "time", 1f));
            iTween.ValueTo(gameObject, iTween.Hash("from", GameManager.scoreP1, "to", GameManager.scoreP1 + 100, "onUpdate", "UpdatePlayerScore1", "time", 0.5f));
        }
    }

    void UpdateFontSize1(int value)
    {
        player1Score.fontSize = value;
    }

    void UpdatePlayerScore1(int value)
    {
        GameManager.scoreP1 = value;
    }

    void UpdateFontSize2(int value)
    {
        player2Score.fontSize = value;
    }

    void UpdatePlayerScore2(int value)
    {
        GameManager.scoreP2 = value;
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
                changeDirection();
                iTween.ShakePosition(cameraObject, new Vector3(0.5f, 0.5f, 0f), 0.2f);
                return;
            }
            if(otherPlayer.getTimeSinceLastRingChange() < timeSinceLastRingChange)
            {
                die();
            }
        }
        else if(collision.gameObject.tag == "Flare")
        {
            iTween.ShakePosition(cameraObject, new Vector3(0.75f, 0.75f, 0.5f), 0.5f);
            iTween.ValueTo(cameraObject, iTween.Hash("from", 1.75f, "to", 0f, "onUpdate", "UpdateChroma", "time", 1f));
            die();
        }
    }

    void UpdateChroma(float value)
    {
        cameraObject.GetComponent<ChromaticAberration>().chromaticAberration = value;
    }

}
