using UnityEngine;

public class HeroShape : MonoBehaviour
{
    public Animator animator { get; private set; }
    public Hero hero { get; private set; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
        hero = GetComponentInParent<Hero>();
    }

    void Update()
    {

    }
}