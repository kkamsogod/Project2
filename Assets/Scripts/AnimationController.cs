using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected SpartaCampController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<SpartaCampController>();
    }
}
