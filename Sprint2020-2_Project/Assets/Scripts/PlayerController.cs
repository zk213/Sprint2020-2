using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float pullSpeed = 1;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    GameObject cameraObject;
    public RingGenerator ringGenerator;
    public Text player1Text;
    public Text player2Text;
    Ammo ammoScript;

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
        //iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "onUpdate", "UpdateChroma", "time", 0.5f));
        }
    }

    void UpdateChroma(float value)
    {
        cameraObject.GetComponent<ChromaticAberration>().chromaticAberration = value;
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
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;

        StartCoroutine(GameManager.restart());
        if (isFirstPlayer)
        {
            //GameManager.scoreP2++;
            //iTween.PunchPosition(player2Text.gameObject, new Vector3(25f, 50f, 0f), 2f);
            //iTween.PunchScale(player2Text.gameObject, new Vector3(5f, 5f, 0f), 2f);
            iTween.ValueTo(gameObject, iTween.Hash("name", "Player2FontPunch", "from", 70, "to", 30, "onUpdate", "Update2FontSize", "time", 1f));
            iTween.ValueTo(gameObject, iTween.Hash("from", GameManager.scoreP2, "to", GameManager.scoreP2 + 100, "onUpdate", "UpdatePlayer2Score", "time", 0.5f));
        }
        else
        {
            //GameManager.scoreP1++;
            //iTween.PunchPosition(player1Text.gameObject, new Vector3(25f, -50f, 0f), 2f);
            //iTween.PunchScale(player1Text.gameObject, new Vector3(5f, 5f, 0f), 2f);
            iTween.ValueTo(gameObject, iTween.Hash("name", "Player1FontPunch", "from", 70, "to", 30, "onUpdate", "Update1FontSize", "time", 1f));
            iTween.ValueTo(gameObject, iTween.Hash("from", GameManager.scoreP1, "to", GameManager.scoreP1 + 100, "onUpdate", "UpdatePlayer1Score", "time", 0.5f));
        }
    }

    void Update1FontSize(int value)
    {
        player1Text.fontSize = value;
    }

    void UpdatePlayer1Score(int value)
    {
        GameManager.scoreP1 = value;
    }

    void Update2FontSize(int value)
    {
        player2Text.fontSize = value;
    }

    void UpdatePlayer2Score(int value)
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
                
                iTween.ShakePosition(cameraObject, new Vector3(0.5f, 0.5f, 0.5f), 0.2f);
                return;
            }
            if(otherPlayer.getTimeSinceLastRingChange() < timeSinceLastRingChange)
            {
                die();
            }
        }
        else if(collision.gameObject.tag == "Flare")
        {
            die();
        }
    }

}
