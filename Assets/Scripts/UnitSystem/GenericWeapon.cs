using UnityEngine;

public class GenericWeapon : Weapon
{
    [Min(0)]
    public int manaCost;
    public float damage = 10;
    public float range = 5;
    public Duration delay = new Duration(.3f);
    public Duration reload = new Duration(1);

    Mana mana => _mana ? _mana : _mana = GetComponentInParent<Mana>();
    Mana _mana;

    AudioSource _audioSource;
    AudioSource audioSource => _audioSource ? _audioSource : _audioSource = GetComponentInChildren<AudioSource>();
    public override void Attack()
    {
        base.Attack();
        if (mana && manaCost > 0)
            mana.UseMana(manaCost);
        if (audioSource)
            audioSource.Play();
    }


    public override bool CanAttack()
    {
        return base.CanAttack() && (mana == null || mana.HasAmount(manaCost));
    }
}