﻿using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public enum MovementStates
    {
        Idle,
        Running,
        Jumping,       
    }
    public enum FacingDirection
    {
        Right,
        Left
    }

    [Header("Movement values")]
    public float movementSpeed;
    public float jumpForce;

    [Header("Raycast length and layerMask")]
    public float isGroundedRayLength;
    public LayerMask platformLayerMask;

    [Header("Movement States")]
    public MovementStates movementState;
    public FacingDirection facingDirection;

    public ParticleSystem dust;

    private bool mobileLeft, mobileRight;
    private Rigidbody2D rigidBody2D;    
    private BoxCollider2D boxCollider2D;
    private CharacterAnimationController animController;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animController = GetComponent<CharacterAnimationController>();      
    }

    private void Update()
    {
        HandleJumping();
    }
    private void FixedUpdate()
    {
        HandleMovement();
        SetCharacterState();
        SetCharacterDirection();
        PlayAnimationsBasedOnState();        
    }

    private void HandleMovement()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A)|| mobileLeft)
        {
            rigidBody2D.velocity = new Vector2(-movementSpeed, rigidBody2D.velocity.y);

            if (IsGrounded())
            {
                CreateDust();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || mobileRight)
            {
                rigidBody2D.velocity = new Vector2(+movementSpeed, rigidBody2D.velocity.y);                
                if (IsGrounded())
                {
                    CreateDust();
                }
                
            }
            else //NO KEYS PRESSED
            {
                rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private void HandleJumping ()
    {
        if (Input.GetKeyDown(KeyCode.W)&& IsGrounded())
        {
            rigidBody2D.velocity = Vector2.up * jumpForce;
            MusicManager.PlaySound("Jump");
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down,
            isGroundedRayLength, platformLayerMask);
        return raycastHit2D.collider != null;    
    }

    private void SetCharacterState ()
    {
        if (IsGrounded())
        {
            if (rigidBody2D.velocity.x == 0)
            {
                movementState = MovementStates.Idle;
            }
            else if (rigidBody2D.velocity.x > 0)
            {
                facingDirection = FacingDirection.Right;
                movementState = MovementStates.Running;
            }
            else if (rigidBody2D.velocity.x < 0)
            {
                facingDirection = FacingDirection.Left;
                movementState = MovementStates.Running;
            }
        }
        else
        {
            movementState = MovementStates.Jumping;
        }              
    }

    private void SetCharacterDirection()
    {
        switch (facingDirection)
        {
            case FacingDirection.Right:
                transform.localScale = new Vector2(1, 1);
                break;
            case FacingDirection.Left:
                transform.localScale = new Vector2(-1, 1);
                break;
        }
    }

    private void PlayAnimationsBasedOnState()
    {
        switch (movementState)
        {
            case MovementStates.Idle:
                animController.PlayIdleAnim();
                break;
            case MovementStates.Running:
                animController.PlayRunningAnim();
                break;
            case MovementStates.Jumping:
                animController.PlayJumpingAnim();
                break;                          
            default:
                break;
        }
    }

    private void CreateDust()
    {
        dust.Play();
    }
    
    /// <summary>
    ///              MOBILE CONTROLS
    /// </summary>
    public void MobileLeftTrue()
    {
        mobileLeft = true;
        mobileRight = false;
    }
    public void MobileRightTrue()
    {
        mobileRight = true;
        mobileLeft = false;
    }
    public void MobileStop()
    {
        mobileLeft = false;
        mobileRight = false;
    }
    public void MobileJump()
    {
        if (IsGrounded())
        {
            rigidBody2D.velocity = Vector2.up * jumpForce;
            MusicManager.PlaySound("Jump");
        }     
    }
}

