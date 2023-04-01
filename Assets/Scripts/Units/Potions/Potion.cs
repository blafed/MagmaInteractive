using UnityEngine;

public class Potion : MonoBehaviour
{
    public int addHp = 20;
    public int addMp = 20;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero hero;
        if (hero = other.GetComponentInParent<Hero>())
        {
            hero.health.AddHp(addHp);
            hero.mana.AddMana(addMp);
            GetComponent<CollapseScale>().enabled = true;
        }
    }
}