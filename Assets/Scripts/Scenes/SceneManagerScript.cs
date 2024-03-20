using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public Animator transitionAnimator;

    float transitionTime = 1.5f;

    float loading1Time = 5f;
    float loading2Time = 4.25f;
    float loading3Time = 3.42f;
    float loading4Time = 4.69f;

    float firstCinematicTime = 64.55f;
    float lastCinematicTime = 11.25f;

    float transitionsDuration = 3.75f;
    float transitionsTryDuration = 1.4f;

    void Start()
    {

    }

    void Update()
    {
        SceneNameCheck();
    }

    void SceneNameCheck()
    {
        if (SceneManager.GetActiveScene().name == "FirstCinematic")
        {
            StartCoroutine(Loading1());
        }

        if (SceneManager.GetActiveScene().name == "Loading1")
        {
            StartCoroutine(ToLevel1());
        }

        if (SceneManager.GetActiveScene().name == "TransitionLegs")
        {
            StartCoroutine(Loading2());
        }

        if (SceneManager.GetActiveScene().name == "Loading2")
        {
            StartCoroutine(ToLevel2());
        }

        if (SceneManager.GetActiveScene().name == "TransitionNoHead")
        {
            StartCoroutine(Loading3());
        }

        if (SceneManager.GetActiveScene().name == "Loading3")
        {
            StartCoroutine(ToLevel3());
        }

        if (SceneManager.GetActiveScene().name == "TransitionBodyComplete")
        {
            StartCoroutine(Loading4());
        }

        if (SceneManager.GetActiveScene().name == "Loading4")
        {
            StartCoroutine(ToEndVideo());
        }

        if (SceneManager.GetActiveScene().name == "LastCinematic")
        {
            StartCoroutine(LoadEnd());
        }
    }


    IEnumerator Loading1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(firstCinematicTime);

        SceneManager.LoadScene("Loading1");
    }

    IEnumerator ToLevel1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(loading1Time);

        SceneManager.LoadScene("Level1");
    }

    IEnumerator Transition1()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTryDuration);

        SceneManager.LoadScene("TransitionLegs");
    }

    IEnumerator Loading2()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsDuration);

        SceneManager.LoadScene("Loading2");
    }

    IEnumerator ToLevel2()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(loading2Time);

        SceneManager.LoadScene("Level2");
    }

    IEnumerator Transition2()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTryDuration);

        SceneManager.LoadScene("TransitionNoHead");
    }

    IEnumerator Loading3()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsDuration);

        SceneManager.LoadScene("Loading3");
    }

    IEnumerator ToLevel3()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(loading3Time);

        SceneManager.LoadScene("Level3");
    }

    IEnumerator Transition3()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTryDuration);

        SceneManager.LoadScene("TransitionBodyComplete");
    }

    IEnumerator Loading4()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsDuration);

        SceneManager.LoadScene("Loading4");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Flag1")
        {
            StartCoroutine(Transition1());
            //StartCoroutine(ToLevel2());
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "Flag2")
        {
            StartCoroutine(Transition2());
            //StartCoroutine(ToLevel3());
        }

        if ((collision.gameObject.tag == "Player" && gameObject.tag == "Flag3") || (collision.gameObject.tag == "Arrow" && gameObject.tag == "Flag3"))
        {
            StartCoroutine(Transition3());
            //StartCoroutine(LoadEnd());
        }
    }

    IEnumerator ToEndVideo()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(loading4Time);

        SceneManager.LoadScene("LastCinematic");
    }


    IEnumerator LoadEnd()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(/*lastCinematicTime*/ loading1Time);

        SceneManager.LoadScene("TheEnd");
    }
}
