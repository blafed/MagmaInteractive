using UnityEngine;

public class PlayAnimationOnKilled : MonoBehaviour
{

    Health health;
    Animator shape;
    private void Awake()
    {
        health = GetComponentInParent<Health>();
        shape = GetComponent<Animator>();
        health.onKilled += OnKilled;
    }

    private void OnKilled()
    {
        shape.Play("Die");
    }
}