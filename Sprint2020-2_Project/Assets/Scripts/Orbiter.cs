using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    private const float MIN_RADIUS = 1;
    private const float MAX_RADIUS = 5;

    [Range(MIN_RADIUS, MAX_RADIUS)]
    public float radius = 1;
    public float targetRadius = 1;
    public float speed = 0;
    public float transitionSpeed = 0;
    public bool moveClockwise = true;

    private float rotationTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
        radius = transform.position.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnd)
        {
            return;
        }

        radius = Mathf.Lerp(radius, targetRadius, transitionSpeed * Time.deltaTime);
        orbit(speed * Time.deltaTime);
    }

    public void orbit(float arcLength)
    {
        int moveDir = 1;
        if (moveClockwise)
        {
            moveDir = -1;
        }

        transform.position = transform.position.normalized * radius;
        float angle = arcLength / radius;
        transform.RotateAround(Vector3.zero, Vector3.forward, moveDir * angle);

        rotationTotal += angle;
    }

    // Returns total angular movement during its lifetime, in degrees
    public float getRotationTotal()
    {
        return rotationTotal;
    }

    public float getDistanceToTargetRadius()
    {
        return Mathf.Abs(targetRadius - radius);
    }
}
