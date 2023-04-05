using UnityEngine;

public class LevelUpTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Hero hero;
        if (hero = other.GetComponentInParent<Hero>())
        {
            Invoke("GoNext", 1);
        }
    }

    private void GoNext()
    {
        GameManager.instance.GoNextLevel();
    }
}