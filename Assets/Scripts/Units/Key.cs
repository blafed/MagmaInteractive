using UnityEngine;


public class Key : MonoBehaviour
{
    public GameObject effectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        var hero = other.GetComponentInParent<Hero>();
        if (hero)
        {
            hero.keys.Add(this);
            if (effectPrefab != null)
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}