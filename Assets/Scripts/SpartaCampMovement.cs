using System;
using UnityEngine;

public class SpartaCampMovement : MonoBehaviour
{
    private SpartaCampController controller;
    private Rigidbody2D movementRigidbody;
    private SpriteRenderer spriteRenderer;

    private Vector2 movementDirection = Vector2.zero;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float slideForce = 10f;
    [SerializeField] private float jumpDistance = 1f;
    [SerializeField] private float slideDuration = 0.3f;
    [SerializeField] private float fallSpeed = 4f;

    private bool isSliding = false;
    private bool isJumping = false;
    private bool isMoving = true;

    private Vector2 originalPosition;
    private float jumpTimer = 0f;
    private float slideTimer = 0f;
    private float fixedYPosition;

    private void Awake()
    {
        controller = GetComponent<SpartaCampController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
        controller.OnSlideEvent += Slide;
    }

    private void Update()
    {
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (jumpTimer >= jumpDistance / jumpForce)
            {
                movementRigidbody.velocity = new Vector2(movementRigidbody.velocity.x, -fallSpeed);
                isJumping = false;
            }
        }

        if (isSliding)
        {
            slideTimer += Time.deltaTime;

            if (slideTimer >= slideDuration)
            {
                isSliding = false;
                isMoving = true;

                if (movementDirection == Vector2.zero)
                {
                    movementRigidbody.velocity = new Vector2(0, movementRigidbody.velocity.y);
                }
            }
            else
            {
                movementRigidbody.velocity = new Vector2(movementRigidbody.velocity.x, 0);
                transform.position = new Vector2(transform.position.x, fixedYPosition);
            }
        }

        if (!isJumping && !isSliding && transform.position.y <= originalPosition.y)
        {
            movementRigidbody.velocity = new Vector2(movementRigidbody.velocity.x, 0);
            isMoving = true;
        }
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
        if (!isSliding)
        {
            movementRigidbody.velocity = new Vector2(movementDirection.x * moveSpeed, movementRigidbody.velocity.y);
        }
    }

    private void Jump()
    {
        if (!isJumping && !isSliding)
        {
            isJumping = true;
            isMoving = false;
            originalPosition = transform.position;
            jumpTimer = 0f;
            movementRigidbody.velocity = new Vector2(movementRigidbody.velocity.x, jumpForce);
        }
    }

    private void Slide()
    {
        if (!isJumping && !isSliding)
        {
            isSliding = true;
            isMoving = false;
            slideTimer = 0f;

            float slideDirection = spriteRenderer.flipX ? -1f : 1f;
            fixedYPosition = transform.position.y;

            movementRigidbody.velocity = new Vector2(slideDirection * slideForce, 0);
        }
    }

    private void FixedUpdate()
    {
        if (isMoving && !isSliding && !isJumping)
        {
            ApplyMovement(movementDirection);
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        movementRigidbody.velocity = direction * moveSpeed;
    }
}