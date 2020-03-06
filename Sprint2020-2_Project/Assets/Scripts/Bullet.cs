using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Orbiter))]
public class Bullet : MonoBehaviour
{
    private Orbiter orbiter;
    GameObject cameraObject;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        orbiter = GetComponent<Orbiter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnd)
        {
            return;
        }

        // Destroy after one full rotation
        if (orbiter.getRotationTotal() > 360 * 2)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (cameraObject != null)
            {
                iTween.ShakePosition(cameraObject, new Vector3(0.75f, 0.75f, 0.5f), 0.5f);
                iTween.ValueTo(gameObject, iTween.Hash("from", 1.75f, "to", 0f, "onUpdate", "UpdateChroma", "time", 1f));
            }
            player.die();
            destroySelf();
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Orbiter myOrbit = GetComponent<Orbiter>();
            Orbiter otherOrbit = collision.gameObject.GetComponent<Orbiter>();

            if (cameraObject != null)
            {
                iTween.PunchPosition(cameraObject, new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0), 0.2f);
            }
            if(myOrbit.moveClockwise != otherOrbit.moveClockwise)
            {
                destroySelf();
            }   
        }
    }

    void UpdateChroma(float value)
    {
        cameraObject.GetComponent<ChromaticAberration>().chromaticAberration = value;
    }

    void destroySelf()
    {
        FindObjectOfType<AudioManager>().Play("BulletExplosion", this.gameObject);
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);
        Destroy(gameObject.transform.GetChild(2).gameObject);
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(this.gameObject, 2);
    }
}
