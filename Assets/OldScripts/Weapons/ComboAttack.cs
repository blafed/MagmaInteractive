using UnityEngine;

public class ComboAttack : Weapon
{
    public float fallbackTime = 0.5f;
    public Weapon[] weapons;


    int weaponIndex = -1;

    public override void Attack()
    {
        base.Attack();
        weaponIndex++;
        if (weaponIndex >= weapons.Length)
            weaponIndex = 0;
        weapons[weaponIndex].Attack();


    }

    void FixedUpdate()
    {
        if (Time.time > reloadTimer + fallbackTime + reload)
            weaponIndex = -1;
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].enabled = weaponIndex == i;
        }
    }



}