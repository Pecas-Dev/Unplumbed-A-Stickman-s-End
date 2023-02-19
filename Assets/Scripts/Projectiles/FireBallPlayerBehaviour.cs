using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class FireBallPlayerBehaviour : MonoBehaviour
{
    CapsuleCollider2D fireballCollider;
    BoxCollider2D boxFireballCollider;
    Rigidbody2D playerRigidbodyAddForce;
    Animator playerFireBallAnimator;
    //AudioSource hitAudio;

    CharacterMovementNoHead characterMovementNoHead;

    Vector2 addForce = new Vector2(-10f, 10f);

    float waitAfterDeath = 4f;

    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        fireballCollider = GetComponent<CapsuleCollider2D>();
        boxFireballCollider= GetComponent<BoxCollider2D>();
        playerRigidbodyAddForce = GetComponent<Rigidbody2D>();
        playerFireBallAnimator = GetComponent<Animator>();
        characterMovementNoHead = FindObjectOfType<CharacterMovementNoHead>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
       // hitAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CheckFireBall();
    }

    void CheckFireBall()
    {
        if(fireballCollider.IsTouchingLayers(LayerMask.GetMask("FireBall")))
        {
            characterMovementNoHead.canMove = false;
            fireballCollider.size = new Vector2(0.69f, 5.3f);
            boxFireballCollider.enabled = false;
            playerRigidbodyAddForce.sharedMaterial = null;
            playerFireBallAnimator.SetBool("isFireBall", true);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            impulseSource.GenerateImpulse(0.05f);
            //hitAudio.Play();
            playerRigidbodyAddForce.velocity = new Vector2(addForce.x, addForce.y);
            StartCoroutine(RestartSceneFireBall());
        }
        if (!fireballCollider.IsTouchingLayers(LayerMask.GetMask("FireBall")))
        {
            return;
        }
    }

    IEnumerator RestartSceneFireBall()
    {
        yield return new WaitForSeconds(waitAfterDeath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
