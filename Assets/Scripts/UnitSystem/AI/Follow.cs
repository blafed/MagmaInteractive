using UnityEngine;

public class Follow : MonoBehaviour
{
    public float maxFollowDistance = 5;
    public float minStopDistance = 0.5f;
    public float speed = 1;
    public bool allowVerticalMovement = false;

    [Header("Unreachable Properties")]
    public Duration maxUnreachableDuration = new Duration(1);
    public float unreachableThreshold = .1f;

    JumpAbility jumpAbility;

    public Transform target { get; set; }


    public bool isCloseToTarget { get; private set; }

    Vector2 unreachableRegisteredPosition;
    Vector2 lastPosition;

    public event System.Func<Vector2, bool> onValidateMovement;


    private void Awake()
    {
        jumpAbility = GetComponent<JumpAbility>();
    }

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
        if (maxUnreachableDuration.isDone)
        {
            unreachableRegisteredPosition = transform.position;
            maxUnreachableDuration.Start();
        }
        bool cannotBeReached = Vector2.Distance(lastPosition, transform.position) < velocity.magnitude * Time.fixedDeltaTime + unreachableThreshold;
        // if (Vector2.Distance(unreachableRegisteredPosition, transform.position) < maxUnreachableDistance)
        // {
        //     cannotBeReached = true;
        // }
        if (cannotBeReached)
        {
            if (jumpAbility)
            {
                if (jumpAbility.CanJump())
                    jumpAbility.Jump();
            }
        }
        lastPosition = transform.position;
        var deltaMovement = velocity * Time.fixedDeltaTime;
        if (!onValidateMovement?.Invoke(deltaMovement) ?? false)
        {
            target = null;
            return;
        }
        transform.position += deltaMovement;
    }
}