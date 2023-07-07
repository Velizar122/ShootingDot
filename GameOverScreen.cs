using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //public Animator animator;
    //public void IdleGameOVer()
    //{
    //    animator.SetBool("Idle", true);
    //}
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //public void Options()
    //{

    //}
}
