using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource source;

    public float songTime = 0f;
    public bool songPaused = false;
    bool isSongEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSong());
    }

    IEnumerator PlayRandomSong()
    {
        while (true)
        {
            AudioClip song = songs[UnityEngine.Random.Range(0, songs.Length)];
            source.clip = song;
            source.Play();
            songPaused = false;
            isSongEnded = false;
            while (source.isPlaying)
            {
                songTime = source.time;

                if (Time.timeScale == 0f)
                {
                    source.Pause();
                    songPaused = true;
                    break;
                }
                yield return null;
            }

            isSongEnded = true;

            while (songPaused)
            {
                yield return null;
                if (Time.timeScale != 0f)
                {
                    source.time = songTime;
                    source.Play();
                    songPaused = false;
                }
            }

            // Select the next song and set it as the clip of the AudioSource
            int index = Array.IndexOf(songs, song);
            index = (index + 1) % songs.Length;
            song = songs[index];
            source.clip = song;

            while (source.isPlaying && Time.timeScale != 0f)
            {
                songTime = source.time;
                yield return null;
            }
        }
    }


    void Update()
    {
        if (!songPaused)
        {
            songTime = source.time;
        }
    }
}
