using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class SceneManagerMainMenu : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("FirstCinematic");
        SceneManager.LoadScene("Level1");
    }
}
