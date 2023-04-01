using UnityEngine;
using UnityEngine.UI;

public class TurnShapeOnDamage : MonoBehaviour
{
    public GameObject targetObject;
    Duration duration = new Duration(.05f);
    Color originalColor;
    Health health;

    bool didStart;

    private void Awake()
    {
    }

    private void Start()
    {
        health = GetComponentInParent<Health>();
        health.onTakeDamage += OnDamage;
        didStart = true;
    }

    private void OnEnable()
    {
        if (!didStart) return;
        duration.Start();
        targetObject.SetActive(true);
    }
    private void OnDisable()
    {
        if (!didStart) return;
        targetObject.SetActive(false);
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