using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCameraSingleton : MonoBehaviour
{
    static MainCameraSingleton mainCameraSingleton_instance;

    void Awake()
    {
        if(mainCameraSingleton_instance == null)
        {
            mainCameraSingleton_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "FirstCinematic")
        {
            Destroy(gameObject);
        }
    }
}
