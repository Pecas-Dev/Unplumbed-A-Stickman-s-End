using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementNoHead : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float walkAnimationSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;

    [Header("Wall")]
    [SerializeField] Transform wallCheck;
    [SerializeField] LayerMask wallLayer;

    Rigidbody2D playerCompleteRigidody;
    BoxCollider2D playerCompleteFeetCollider;
    CapsuleCollider2D playerCompleteCapsuleCollider;
    Animator playerCompleteAnimator;

    float xInputValue;
    float yInputValue;

    public bool canMove = true;

    //They don't do nothing, but somehow my code works with them /:
    bool hasJumped;
    bool hasWallJumped;

    Vector2 secondJumpPower = new Vector2(0f, 0f);

    float wallSlidngSpeed = 2f;
    bool isWallSliding;

    Vector2 wallJumpingPower = new Vector2(10f, 8f);
    bool iswallJumping;
    float wallJumpingDirection;
    float wallJumpingTime = 0.2f;
    float wallJumpingCounter;
    float wallJumpingDuration = 0.4f;

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
        WallSlide();
        WallJump();

        if (!iswallJumping)
        {
            FlipCompleteCharacter();
        }
    }

    void MovePlayerComplete()
    {
        if (canMove) 
        {
            xInputValue = Input.GetAxis("Horizontal");
            yInputValue = Input.GetAxis("Vertical");

            Vector2 playerCompleteVelocity = new Vector2(xInputValue * playerSpeed, playerCompleteRigidody.velocity.y);

            if (!iswallJumping)
            {
                playerCompleteRigidody.velocity = playerCompleteVelocity;
            }
        }
        

        bool isMovingHorizontal = Mathf.Abs(playerCompleteRigidody.velocity.x) > Mathf.Epsilon;

        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) || playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
        {
            playerCompleteAnimator.SetBool("isWalkingNoHead", isMovingHorizontal);
            playerCompleteAnimator.SetFloat("walkSpeedNoHead", walkAnimationSpeed);
        }
        else
        {
            playerCompleteAnimator.SetBool("isWalkingNoHead", isMovingHorizontal);
            playerCompleteAnimator.SetFloat("walkSpeedNoHead", 0f);
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

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    void WallSlide()
    {
        bool isGrounded = playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (IsWalled() && !isGrounded && xInputValue != 0)
        {
            isWallSliding = true;
            playerCompleteRigidody.velocity = new Vector2(playerCompleteRigidody.velocity.x, Mathf.Clamp(playerCompleteRigidody.velocity.y, -wallSlidngSpeed, float.MaxValue));
            playerCompleteAnimator.SetBool("isWalkingNoHead", false);
        }
        else
        {
            isWallSliding = false;
        }
    }

    void WallJump()
    {
        if (isWallSliding)
        {
            iswallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            iswallJumping = true;
            playerCompleteRigidody.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                FlipCompleteCharacter();
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    void StopWallJumping()
    {
        iswallJumping = false;
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
