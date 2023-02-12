using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
