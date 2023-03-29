using UnityEngine;

public class Weapon : MonoBehaviour
{

    public virtual string animationName { get; }
    public virtual bool isAttacking => false;
    public virtual bool CanAttack() => true;
    public virtual void Attack() { }
}