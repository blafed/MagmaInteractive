using Mono.CompilerServices.SymbolWriter;

using UnityEngine;

public class LimitLifetime : MonoBehaviour
{
    public Duration lifeTime = new Duration(1);
    public bool kill;

    private void Start()
    {
        lifeTime.Start();
    }

    private void FixedUpdate()
    {
        if (lifeTime.isDone)
        {
            enabled = false;
            if (kill)
                GetComponentInParent<Health>().Kill();
            else
                Destroy(gameObject);
        }
    }


}