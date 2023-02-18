using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementLegs : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float walkAnimationSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D playerCompleteRigidody;
    BoxCollider2D playerCompleteFeetCollider;
    CapsuleCollider2D playerCompleteCapsuleCollider;
    Animator playerCompleteAnimator;


    float xInputValue;
    float yInputValue;

    //They don't do nothing, but somehow my code works with them /:
    bool hasJumped;
    bool hasWallJumped;

    Vector2 secondJumpPower = new Vector2(0f, 0f);

    void Start()
    {
        playerCompleteAnimator = GetComponent<Animator>();
        playerCompleteRigidody = GetComponent<Rigidbody2D>();
        playerCompleteFeetCollider = GetComponent<BoxCollider2D>();
        playerCompleteCapsuleCollider = GetComponent<CapsuleCollider2D>();
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

        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            playerCompleteAnimator.SetBool("isWalkingLegs", isMovingHorizontal);
            playerCompleteAnimator.SetFloat("walkSpeedLegs", walkAnimationSpeed);
        }
        else
        {
            playerCompleteAnimator.SetBool("isWalkingLegs", isMovingHorizontal);
            playerCompleteAnimator.SetFloat("walkSpeedLegs", 0f);
        }
    }

    void FlipCompleteCharacter()
    {
        bool isMovingHorizontal = Mathf.Abs(playerCompleteRigidody.velocity.x) > Mathf.Epsilon;

        if (isMovingHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerCompleteRigidody.velocity.x) * 0.3f, 0.3f);
        }
    }

    void JumpPlayerComplete()
    {
        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            hasJumped = false;
            hasWallJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!hasJumped)
            {
                playerCompleteRigidody.velocity = new Vector2(0, jumpSpeed);
                hasJumped = true;
                hasWallJumped = false;
            }
            else if (playerCompleteCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !hasWallJumped)
            {
                playerCompleteRigidody.velocity = new Vector2(secondJumpPower.x, secondJumpPower.y);
                hasWallJumped = true;
            }
        }

    }
}
