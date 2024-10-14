using System;
using UnityEngine;

public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isJumping = Animator.StringToHash("isJumping");
    private static readonly int isSliding = Animator.StringToHash("isSliding");

    private readonly float manituteThreshold = 0.5f;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += move;
        controller.OnJumpEvent += jump;
        controller.OnSlideEvent += slide;
    }

    private void move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > manituteThreshold);
    }

    private void jump()
    {
        animator.SetTrigger(isJumping);
    }

    private void slide()
    {
        animator.SetTrigger(isSliding);
    }
}