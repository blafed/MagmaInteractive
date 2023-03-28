using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened;



    void OnTriggerEnter2D(Collider2D other)
    {
        Hero hero;
        if (hero = other.GetComponentInParent<Hero>())
        {
            if (hero.doorKeys.Count > 0)
            {
                var key = hero.doorKeys.Dequeue();
                isOpened = true;
            }
        }
    }
}