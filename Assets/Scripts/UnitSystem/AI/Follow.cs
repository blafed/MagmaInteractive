using Codice.Client.Commands.TransformerRule;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float minStopDistance = 0.5f;
    public float speed = 1;
    public bool allowVerticalMovement = false;
    public Transform target { get; set; }


    private void FixedUpdate()
    {
        if (target == null)
            return;

        var targetPosition = target.position;
        if (!allowVerticalMovement)
            targetPosition.y = transform.position.y;

        var direction = targetPosition - transform.position;
        var distance = direction.magnitude;
        var velocity = direction.normalized * speed;

        if (distance < minStopDistance)
        {
            transform.position = targetPosition;
            return;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }
}