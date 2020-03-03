using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    private const float MIN_RADIUS = 1;
    private const float MAX_RADIUS = 5;

    [Range(MIN_RADIUS, MAX_RADIUS)]
    public float radius = 1;
    public float speed = 0;
    public bool moveClockwise = true;

    // Start is called before the first frame update
    void Start()
    {
        radius = transform.position.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 1;
        if(moveClockwise)
        {
            moveDir = -1;
        }

        transform.position = transform.position.normalized * radius;
        transform.RotateAround(Vector3.zero, Vector3.forward, speed * moveDir * Time.deltaTime);
    }
}
