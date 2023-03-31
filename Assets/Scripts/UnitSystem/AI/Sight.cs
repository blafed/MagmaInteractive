using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public event System.Action<GameObject> onTargetEnter;
    public event System.Action<GameObject> onTargetExit;

    public float range = 5f;
    public Duration searchInterval = new Duration(0.5f);
    public LayerMask targetMask = 1 << Layers.Player;


    List<GameObject> targets = new List<GameObject>();

    void Start()
    {
        searchInterval.Start();
    }

    void Search()
    {
        searchInterval.Start();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, targetMask);
        foreach (var collider in colliders)
        {
            onTargetEnter?.Invoke(collider.gameObject);
        }
    }
    void FixedUpdate()
    {
        if (searchInterval.isDone)
        {
            Search();
            searchInterval.Start();
        }

        //remove any targets that are out of range
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
                i--;
                continue;
            }

            if ((targets[i].transform.position - transform.position).sqrMagnitude > range.Squared())
            {
                onTargetExit?.Invoke(targets[i]);
                targets.RemoveAt(i);
                i--;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}