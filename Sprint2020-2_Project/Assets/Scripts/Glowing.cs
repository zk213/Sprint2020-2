using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowing : MonoBehaviour
{
    SpriteRenderer m_render;

   
    // Start is called before the first frame update
    void Start()
    {
        //m_Material = GetComponent<SpriteRenderer>().material;
        m_render = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        m_render.material.SetFloat("_AlphaIntensity_Fade_1", Mathf.PingPong(Time.time, 1.0f));

        m_render.material.SetFloat("_AlphaIntensity_Fade_2", Mathf.PingPong(Time.time, 1.0f));
        m_render.material.SetFloat("_OperationBlend_Fade_1", Mathf.PingPong(Time.time, 3.0f));



    }
}
