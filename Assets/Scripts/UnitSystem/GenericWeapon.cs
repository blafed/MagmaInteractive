using UnityEngine;

public class GenericWeapon : Weapon
{
    public float damage = 10;
    public float range = 5;
    public Duration delay = new Duration(.3f);
    public Duration reload = new Duration(1);
}