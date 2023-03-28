using UnityEngine;

public class RemoveAtFar : MonoBehaviour
{
    public float maxDistance = 10;


    Vector2 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if ((startPosition - (Vector2)transform.position).sqrMagnitude > maxDistance.Squared())
        {
            Destroy(gameObject);
        }
    }
}