using System.Collections.Generic;
using UnityEngine;

public abstract class NpcCondition : MonoBehaviour
{
    public List<NpcAction> actions = new List<NpcAction>();
    public virtual bool Check()
    {
        return false;
    }


    protected virtual void FixedUpdate()
    {
        if (Check())
        {
            foreach (var action in actions)
            {
                action.Run();
            }
        }
    }
}