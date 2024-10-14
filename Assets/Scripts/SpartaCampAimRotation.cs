using System;
using UnityEngine;

public class SpartaCampAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private SpartaCampController controller;

    private void Awake()
    {
        controller = GetComponent<SpartaCampController>();
    }
    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}