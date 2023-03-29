using UnityEngine;

public class CreateObjectOnKilled : MonoBehaviour
{
    Health health;

    [SerializeField] GameObject killEffect;

    private void Awake()
    {
        health = GetComponentInParent<Health>();
        health.onKilled += OnKilled;
    }



    protected virtual void OnKilled()
    {
        if (killEffect)
            Instantiate(killEffect, transform.position, Quaternion.identity);
        // Create object
        // Destroy object
    }



}