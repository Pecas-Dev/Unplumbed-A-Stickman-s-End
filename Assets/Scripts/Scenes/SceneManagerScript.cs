using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transitionAnimator;

    float transitionTime = 1.5f;
    float loading1Time = 5f;
    float videoTime = 4.2f;

    void Start()
    {

    }

    void Update()
    {
        SceneNameCheck();
    }

    void SceneNameCheck()
    {
        if (SceneManager.GetActiveScene().name == "Loading1") //3. Checks if it is in Loading1
        {
            StartCoroutine(LoadVideo()); //4. Video1
        }

        if (SceneManager.GetActiveScene().name == "ProtoVideoScene") //4.3. Checks if it is in Video
        {
            StartCoroutine(LoadLevel2()); //5. Level2
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Flag1")
        {
            StartCoroutine(Loading1()); //2. The way to access the Loading1 in Level1
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Flag2")
        {
            StartCoroutine(LoadEnd()); //6.1. The way to access the End in Level2
        }
    }

    IEnumerator ToLevel1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime); //1. Time before Level1

        SceneManager.LoadScene("Level1"); //1.1. Starts Level1
    }

    IEnumerator Loading1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime); //2.1. Time before moving to Loading1

        SceneManager.LoadScene("Loading1"); //2.2. Starts Loading1
    }

    IEnumerator LoadVideo()
    {
        yield return new WaitForSeconds(loading1Time); //3.1.Time before Video1

        SceneManager.LoadScene("ProtoVideoScene"); //4.2. Starts the video1
    }

    IEnumerator LoadLevel2()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(videoTime); //5.1. Time that takes before moving to Level2

        SceneManager.LoadScene("Level2"); //5.2. Starts Level2
    }

    IEnumerator LoadEnd()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime); //6 Time that takes before moving to Level2

        SceneManager.LoadScene("TheEnd"); //6.2. Starts End
    }
}
