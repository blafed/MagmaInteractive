using UnityEngine;

public class ComboAttack : Weapon
{
    public override bool isAttacking => currentWeapon && currentWeapon.isAttacking;
    public override string animationName => currentWeapon ? currentWeapon.animationName : null;

    public Duration reload = new Duration(1f);
    public Duration fallback = new Duration(.25f);

    public Weapon[] weapons;
    public Weapon currentWeapon => weapons.Length > 0 && weaponIndex >= 0 ? weapons[weaponIndex] : null;
    public int weaponIndex { get; private set; } = -1;

    public override bool CanAttack() => reload.isDone;
    public override void Attack()
    {
        weaponIndex = (weaponIndex + 1) % weapons.Length;
        currentWeapon.Attack();
        fallback.Start();
        reload.Start();
    }


    private void FixedUpdate()
    {

        if (fallback.elabsed > fallback.value + reload.value)
        {
            weaponIndex = -1;
        }

    }

}