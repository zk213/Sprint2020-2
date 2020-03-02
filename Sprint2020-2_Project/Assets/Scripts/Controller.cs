using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float leftWalkSpeed;
    public float rightWalkSpeed;



    public float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            angle -= leftWalkSpeed;
            angle = angle % 360;

            transform.eulerAngles = new Vector3(0, 0, angle);


        }


        if (Input.GetKey(KeyCode.RightArrow))

        {

            angle += rightWalkSpeed;
            angle = angle % 360;

            transform.eulerAngles = new Vector3(0, 0, angle);




        }
        if (Input.GetKey(KeyCode.UpArrow))
        {


        }
        if (Input.GetKey(KeyCode.DownArrow))
        {


        }


    }



}
