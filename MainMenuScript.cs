using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject buttons;
    public Animator  animator;
    public int counter = 0;

    void Start()
    {
        buttons.SetActive(false);
    }

    void Update()
    {
        if (counter==1)
        {
            buttons.SetActive(true);
            animator.SetBool("Stoped", true);
        }
        if (counter == 2)
        {
            buttons.SetActive(false);
            animator.SetBool("Stoped", false);
            counter = 0;
        }
    }

    public void Button()
    {
        counter++;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    //public void Options()
    //{

    //}
    //public void Weapons()
    //{

    //}
}
