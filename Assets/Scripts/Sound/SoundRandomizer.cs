using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioSource source;

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
            AudioClip song = songs[Random.Range(0, songs.Length)];
            source.clip = song;
            source.Play();
            yield return new WaitForSeconds(song.length);
        }
    }
}
