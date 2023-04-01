using Codice.Client.Commands.TransformerRule;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public Transform target { get; set; }
    public float speed = 1;


    private void FixedUpdate()
    {
        if (target == null) return;
        var dir = target.position - transform.position;
        var velocity = dir.normalized * speed;
        transform.position += (Vector3)velocity * Time.fixedDeltaTime;
    }
}