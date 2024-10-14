using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : SpartaCampController
{
    private new Camera camera;

    private Transform player;

    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            CallJumpEvent();
        }
    }

    public void OnSlide(InputValue value)
    {
        if (value.isPressed)
        {
            CallSlideEvent();
        }
    }
}