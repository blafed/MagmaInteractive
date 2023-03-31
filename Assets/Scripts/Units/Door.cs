using UnityEngine;


public class Door : MonoBehaviour
{
    public Key key;
    public bool isOpened { get; private set; }
    Animator animator;
    new Collider2D collider;

    private void Awake()
    {
        GameLevel.current.doors.Add(this);
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();

        if (!key)
        {
            Debug.LogError("Door has no key assigned", gameObject);
        }
    }
    public void Open()
    {
        isOpened = true;
        animator.Play("Open");
        collider.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpened)
            return;
        var hero = other.GetComponentInParent<Hero>();
        if (hero)
        {
            if (hero.keys.Contains(key))
            {
                Open();
            }
        }
    }
}