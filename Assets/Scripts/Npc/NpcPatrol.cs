using UnityEngine;

public class NpcPatrol : MonoBehaviour
{
    public float patrolDuration = 1;
    public float restDuration = 2;

    Character character;


    Vector2 startPosition;


    private void Start()
    {
        character = GetComponentInParent<Character>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {

    }

}