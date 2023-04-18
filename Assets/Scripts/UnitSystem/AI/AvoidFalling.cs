using UnityEngine;

public class AvoidFalling : MonoBehaviour
{
    public float checkEvery = .5f;


    private void Start()
    {
        Patrol patrol = GetComponent<Patrol>();
        Follow follow = GetComponent<Follow>();
        if (patrol)
            patrol.onValidateMovement += OnValidateMovement;
        if (follow)
            follow.onValidateMovement += OnValidateMovement;
    }


    bool OnValidateMovement(Vector2 deltaMovement)
    {
        var position = transform.position;
        var ray = new Ray(position + (Vector3)deltaMovement, Vector3.down);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, .5f);
        if (hit.collider == null)
        {
            return false;
        }
        return true;
    }

}