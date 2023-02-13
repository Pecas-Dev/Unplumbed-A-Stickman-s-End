using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementComplete : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D playerCompleteRigidody;
    BoxCollider2D playerCompleteFeetCollider;
    Animator playerCompleteAnimator;


    float xInputValue;
    float yInputValue;


    void Start()
    {
        playerCompleteAnimator = GetComponent<Animator>();
        playerCompleteRigidody = GetComponent<Rigidbody2D>();
        playerCompleteFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        MovePlayerComplete();
        JumpPlayerComplete();
        FlipCompleteCharacter();
    }

    void MovePlayerComplete()
    {
        xInputValue = Input.GetAxis("Horizontal");
        yInputValue = Input.GetAxis("Vertical");

        Vector2 playerCompleteVelocity = new Vector2(xInputValue * playerSpeed, playerCompleteRigidody.velocity.y);
        playerCompleteRigidody.velocity = playerCompleteVelocity;

        bool isMovingHorizontal = Mathf.Abs(playerCompleteRigidody.velocity.x) > Mathf.Epsilon;

        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            playerCompleteAnimator.SetBool("isWalking", isMovingHorizontal);
        }
    }

    void FlipCompleteCharacter()
    {
        bool isMovingHorizontal = Mathf.Abs(playerCompleteRigidody.velocity.x) > Mathf.Epsilon;

        if (isMovingHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerCompleteRigidody.velocity.x) * 0.2f, 0.2f);
        }
    }

    void JumpPlayerComplete()
    {
        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerCompleteRigidody.velocity += new Vector2(0f, jumpSpeed);
            }
        }

        if (!playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
    }
}
