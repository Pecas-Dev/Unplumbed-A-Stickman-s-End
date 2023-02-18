using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;

    [SerializeField] GameObject pauseUI;
    [SerializeField] AudioSource audioPaused;

    [SerializeField] SoundRandomizer soundRandomizer;

    float audioTime = 0f;

    void Start()
    {
        soundRandomizer = FindAnyObjectByType<SoundRandomizer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
                audioPaused.Play();
            }

            else
            {
                PauseGame();
                audioPaused.Stop();
            }
        }
    }

    void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        soundRandomizer.songPaused = false;
        if (audioPaused.isPlaying)
        {
            audioPaused.Stop();
        }
        if (soundRandomizer.songTime > 0f)
        {
            soundRandomizer.source.time = soundRandomizer.songTime;
        }
        soundRandomizer.source.Play();
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        audioTime = soundRandomizer.songTime;
        audioPaused.time = audioTime;
        soundRandomizer.songPaused = true;
        soundRandomizer.source.Pause();
    }


    private void OnApplicationQuit()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            soundRandomizer.source.UnPause();
        }
    }

}
