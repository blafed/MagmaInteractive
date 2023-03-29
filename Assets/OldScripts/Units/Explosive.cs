using UnityEngine;

public class Explosive : MonoBehaviour
{

    public float damage = 10;
    public float rangeOfDamage => transform.lossyScale.x * collider.radius;


    SphereCollider collider;


    private void Awake()
    {
        collider = GetComponent<SphereCollider>();
    }

    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponentInParent<Health>();
        if (health != null)
        {
            var closestPoint = other.ClosestPoint(transform.position);
            var dst = ((Vector2)transform.position - closestPoint).sqrMagnitude;
            var ratio = Mathf.Clamp01(1 - dst / rangeOfDamage);
            health.TakeDamage(damage * ratio, this);
        }
    }
}