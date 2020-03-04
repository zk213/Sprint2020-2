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
        
    }
    public void ShowTutorialPannel()
    {
        m_animator.SetTrigger("Move");

    }

    
}
