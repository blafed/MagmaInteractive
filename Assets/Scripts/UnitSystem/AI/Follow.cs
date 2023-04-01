using UnityEngine;

public class Follow : MonoBehaviour
{
    public float maxFollowDistance = 5;
    public float minStopDistance = 0.5f;
    public float speed = 1;
    public bool allowVerticalMovement = false;

    public Transform target { get; set; }


    public bool isCloseToTarget { get; private set; }


    private void FixedUpdate()
    {
        if (target == null)
            return;

        var targetPosition = target.position;
        if (!allowVerticalMovement)
            targetPosition.y = transform.position.y;

        var direction = targetPosition - transform.position;


        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        var distance = direction.magnitude;
        var velocity = direction.normalized * speed;

        isCloseToTarget = distance < minStopDistance;
        if (isCloseToTarget)
        {
            return;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }
}