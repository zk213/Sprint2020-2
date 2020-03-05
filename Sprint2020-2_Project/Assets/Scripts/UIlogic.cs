using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIlogic : MonoBehaviour
{
    Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowTutorialPannel();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowTutorialPannel();
        }
    }
    public void ShowTutorialPannel()
    {
       // FindObjectOfType<AudioManager>().Play("sfd");

        m_animator.SetTrigger("Move");

    }

    
}
