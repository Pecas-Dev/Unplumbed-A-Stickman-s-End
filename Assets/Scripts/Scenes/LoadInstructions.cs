using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInstructions : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject instructionsCanvas;

    void Awake()
    {
        mainMenuCanvas.SetActive(true);
        instructionsCanvas.SetActive(false);
    }

    public void Instructions()
    {
        mainMenuCanvas.SetActive(false);
        instructionsCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        mainMenuCanvas.SetActive(true);
        instructionsCanvas.SetActive(false);
    }

}
