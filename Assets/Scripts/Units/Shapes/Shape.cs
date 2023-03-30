using UnityEngine;

public class Shape : MonoBehaviour
{
    public new SpriteRenderer renderer { get; private set; }
    public Animator animator { get; private set; }

    public AnimationState state { get; set; }


    private void Awake()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        animator.SetInteger("State", (int)state);
    }
}