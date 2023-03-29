using UnityEngine;

public class MeleeWeaponTrigger : MonoBehaviour
{

    MeleeWeapon meleeWeapon;

    private void Awake()
    {
        meleeWeapon = GetComponentInParent<MeleeWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        meleeWeapon.OnTriggerEnter2D(other);
    }
}