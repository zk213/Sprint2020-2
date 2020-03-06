using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIlogic : MonoBehaviour
{
    Animator m_animator;
    [SerializeField]
    private GameObject helpUI;

    private bool isHelpOn = true;

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
            if (isHelpOn)
            {
                helpUI.SetActive(false);
                isHelpOn = false;
            }
            else
            {
                helpUI.SetActive(true);
                isHelpOn = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isHelpOn)
            {
                helpUI.SetActive(false);
                isHelpOn = false;
            }
            else
            {
                helpUI.SetActive(true);
                isHelpOn = true;
            }
        }
    }
    //public void ShowTutorialPannel()
    //{
    //   // FindObjectOfType<AudioManager>().Play("sfd");

    //    m_animator.SetTrigger("Move");

    //}

    
}
