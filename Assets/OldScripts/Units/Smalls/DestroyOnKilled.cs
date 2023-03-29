using UnityEngine;

public class DestroyOnKilled : CreateObjectOnKilled
{
    protected override void OnKilled()
    {
        base.OnKilled();
        Destroy(gameObject);
    }
}