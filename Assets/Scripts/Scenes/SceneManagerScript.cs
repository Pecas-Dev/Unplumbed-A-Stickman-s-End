using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transitionAnimator;

    float transitionTime = 1.5f;
    float videoTime = 42f;

    void Start()
    {

    }

    void Update()
    {
        SceneNameCheck();
    }

    void SceneNameCheck()
    {
        if (SceneManager.GetActiveScene().name == "Loading1")
        {
            StartCoroutine(LoadVideo());
        }

        if (SceneManager.GetActiveScene().name == "ProtoVideoScene")
        {
            StartCoroutine(LoadEnd());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Square1")
        {
            StartCoroutine(Loading1());
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Square2")
        {
            StartCoroutine(ToLevel1());
        }
    }

    IEnumerator ToLevel1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Level1");
    }

    IEnumerator Loading1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Loading1");
    }

    IEnumerator LoadVideo()
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("ProtoVideoScene");
    }

    IEnumerator LoadEnd()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(videoTime);

        SceneManager.LoadScene("TheEnd");
    }
}
