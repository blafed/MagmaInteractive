using UnityEngine;

public class Ghoul : Enemy
{
    protected override void OnTargetExist()
    {
        base.OnTargetExist();
        SetFollowTarget(true);
    }
}