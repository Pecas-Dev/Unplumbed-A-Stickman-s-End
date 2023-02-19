using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInstructions : MonoBehaviour
{
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
