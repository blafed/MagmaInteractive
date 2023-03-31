using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : DamageBase
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollider(other);
    }

}