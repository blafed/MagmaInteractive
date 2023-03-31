using UnityEngine;
using UnityEngine.UI;

public class FlashShapeOnDamage : MonoBehaviour
{
    public Color targetColor = Color.red;
    Duration duration = new Duration(.05f);
    new SpriteRenderer renderer;
    Color originalColor;
    Mask mask;
    Health health;

    bool didStart;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        mask = GetComponent<Mask>();
        originalColor = renderer.color;
    }

    private void Start()
    {
        health = GetComponentInParent<Health>();
        health.onTakeDamage += OnDamage;
        didStart = true;
        originalColor = renderer.color;
    }

    private void OnEnable()
    {
        if (!didStart) return;
        duration.Start();
        renderer.color = targetColor;
    }
    private void OnDisable()
    {
        if (!didStart) return;
        renderer.color = originalColor;
    }


    void OnDamage(float v)
    {
        enabled = true;
    }

    private void Update()
    {
        if (duration.isDone)
        {
            enabled = false;
        }
    }




}