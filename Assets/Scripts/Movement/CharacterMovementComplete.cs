using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementComplete : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float firstJumpForce = 5f;
    [SerializeField] float secondJumpForce = 2f;
    [SerializeField] float walkAnimationSpeed = 1f;
    //[SerializeField] float jumpSpeed = 5f;


    Rigidbody2D playerCompleteRigidody;
    BoxCollider2D playerCompleteFeetCollider;
    CapsuleCollider2D playerCompleteCapsuleCollider;
    Animator playerCompleteAnimator;

    SwingMovement swing;

    float xInputValue;
    float yInputValue;

    bool hasJumped;
    bool hasWallJumped;

    void Start()
    {
        playerCompleteAnimator = GetComponent<Animator>();
        playerCompleteRigidody = GetComponent<Rigidbody2D>();
        playerCompleteFeetCollider = GetComponent<BoxCollider2D>();
        playerCompleteCapsuleCollider = GetComponent<CapsuleCollider2D>();
        swing = FindObjectOfType<SwingMovement>();
    }

    void Update()
    {
        MovePlayerComplete();
        JumpPlayerComplete();
        FlipCompleteCharacter();
        Swinging();
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
            playerCompleteAnimator.SetFloat("walkSpeed", walkAnimationSpeed);
        }
    }

    void Swinging()
    {
        if (!playerCompleteCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Swing")))
        {
            playerCompleteAnimator.SetBool("isSwing", false);
            return;
        }

        if (playerCompleteCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Swing")) && swing.attached)
        {
            playerCompleteAnimator.SetBool("isSwing", true);
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
        /*if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerCompleteRigidody.velocity += new Vector2(0f, jumpSpeed);
            }
        }

        if (!playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }*/

        if (playerCompleteFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            hasJumped = false;
            hasWallJumped = false; 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!hasJumped)
            {
                playerCompleteRigidody.velocity = new Vector2(0, firstJumpForce);
                hasJumped = true;
                hasWallJumped = false; 
            }
            else if (playerCompleteCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !hasWallJumped && playerCompleteCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
            {
                playerCompleteRigidody.velocity = new Vector2(0, secondJumpForce);
                hasWallJumped = true; 
            }
        }

    }


}
