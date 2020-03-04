using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Orbiter))]
public class Bullet : MonoBehaviour
{
    private Orbiter orbiter;

    // Start is called before the first frame update
    void Start()
    {
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
            player.die();
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Orbiter myOrbit = GetComponent<Orbiter>();
            Orbiter otherOrbit = collision.gameObject.GetComponent<Orbiter>();
            if(myOrbit.moveClockwise != otherOrbit.moveClockwise)
            {
                Destroy(this.gameObject);
            }   
        }
    }
}
