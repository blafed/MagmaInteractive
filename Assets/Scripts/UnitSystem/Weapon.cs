using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string animationName { get; set; }
    public virtual bool isAttacking => false;
    public virtual bool CanAttack() => true;
    public virtual void Attack() { }
}