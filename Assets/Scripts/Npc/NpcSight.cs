using UnityEngine;

public class NpcSight : MonoBehaviour
{
    public NpcTarget target { get; private set; }
    public event System.Action<NpcTarget> onTargetFound;
    public event System.Action<NpcTarget> onTargetLost;
    public float sight = 2;
    public float searchInterval = 1;

    float searchTimer;

    private void FixedUpdate()
    {
        searchTimer -= Time.deltaTime;

        if (!target)
        {


            if (searchTimer <= 0)
            {
                searchTimer = searchInterval;
                Search();
            }
        }
        else
        {

            var dstSqr = ((Vector2)transform.position - (Vector2)target.position).sqrMagnitude;

            if (dstSqr > sight.Squared())
            {
                var t = target;
                target = null;

                onTargetLost?.Invoke(t);
            }
        }

    }

    void Search()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, sight);
        foreach (Collider2D collider in colliders)
        {
            NpcTarget target = collider.GetComponent<NpcTarget>();
            if (target)
            {
                SetFoundTarget(target);
                break;
            }
        }
    }

    public void SetFoundTarget(NpcTarget target)
    {
        this.target = target;
        onTargetFound?.Invoke(target);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sight);
    }
}