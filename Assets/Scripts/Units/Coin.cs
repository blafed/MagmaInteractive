using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public int deadLayer = Layers.PlayerProjectile;

    bool taken = false;

    void Take(Hero hero)
    {
        hero.collectedCoins += value;
        GetComponent<CollapseScale>().enabled = true;
        gameObject.layer = deadLayer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (taken)
            return;
        Hero hero;
        if (hero = other.GetComponentInParent<Hero>())
        {
            Take(hero);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (taken)
            return;
        Hero hero;
        if (hero = other.gameObject.GetComponentInParent<Hero>())
        {
            Take(hero);
        }
    }
}