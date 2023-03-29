using UnityEngine;

public class ComboAttack : Weapon
{
    public override bool isAttacking => true;

    public Duration reload = new Duration(1f);
    public Duration fallback = new Duration(.25f);

    public Weapon[] weapons;
    public Weapon currentWeapon => weapons.Length > 0 && weaponIndex >= 0 ? weapons[weaponIndex] : null;
    public int weaponIndex { get; private set; } = 0;

    public override bool CanAttack() => reload.isDone;
    public override void Attack()
    {
        var weapon = currentWeapon;
        if (weapon == null)
            return;

        if (weapon.CanAttack())
        {
            weapon.Attack();
            return;
        }

        var nextWeapon = weapons[(weaponIndex + 1) % weapons.Length];
        if (nextWeapon.CanAttack())
        {
            weaponIndex = (weaponIndex + 1) % weapons.Length;
            nextWeapon.Attack();
        }


        reload.Start();
    }


    private void FixedUpdate()
    {
        if (fallback.isDone)
        {
            weaponIndex = 0;
        }

    }

}