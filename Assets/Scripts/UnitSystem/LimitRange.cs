using UnityEngine;

public class LimitRange : MonoBehaviour
{
    public float range = 10;
    public bool kill;

    Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if ((startPosition - (Vector2)transform.position).sqrMagnitude > range.Squared())
        {
            enabled = false;
            if (kill)
                GetComponentInParent<Health>().Kill();
            else
                Destroy(gameObject);
        }
    }
}