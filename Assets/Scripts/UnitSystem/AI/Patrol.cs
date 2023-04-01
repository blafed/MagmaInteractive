using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 1;
    public float distance = 4;

    public Duration rest = new Duration(2);
    public Duration maxPatrolDuration = new Duration(4);
    float movementDir = 1;



    Vector2 position
    {

        get => transform.position;
        set => transform.position = value;
    }
    Vector2 startPatrolPoint;

    private void Start()
    {
        rest.value *= Random.Range(.7f, 1.3f);
    }

    private void OnEnable()
    {
        maxPatrolDuration.Start();
        rest.Start();
        startPatrolPoint = position;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(startPatrolPoint, position) >= distance || maxPatrolDuration.postElabsed > rest.value)
        {
            maxPatrolDuration.Start();
            rest.Start();
            movementDir *= -1;
            startPatrolPoint = position;
        }
        else if (rest.isDone)
        {
            var velocity = Vector2.right * speed * movementDir;
            position += velocity * Time.fixedDeltaTime;
            transform.localScale = new Vector3(movementDir, transform.localScale.y, transform.localScale.z);
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, position + Vector2.right * distance);
    }
}