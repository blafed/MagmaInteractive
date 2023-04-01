using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum Direction
    {
        Horizontal,
        Vertical
    }
    public Direction direction = Direction.Horizontal;
    public float speed = 1;
    public float distance = 4;

    public Duration rest = new Duration();
    float movementDir = 1;



    Vector2 position
    {

        get => transform.position;
        set => transform.position = value;
    }
    Vector2 startPatrolPoint;


    private void OnEnable()
    {
        rest.Start();
        startPatrolPoint = position;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(startPatrolPoint, position) >= distance)
        {
            rest.Start();
            movementDir *= -1;
            startPatrolPoint = position;
        }
        else if (rest.isDone)
        {
            var velocity = (direction == Direction.Horizontal ? Vector2.right : Vector2.up) * speed * movementDir;
            position += velocity * Time.fixedDeltaTime;
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, position + (direction == Direction.Horizontal ? Vector2.right * distance : Vector2.up * distance));
    }
}