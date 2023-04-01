using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    Health _health;
    public Health ownerHealth => _health ? _health : _health = GetComponentInParent<Health>();

    [FormerlySerializedAs("animationName")]
    [SerializeField]
    string _animationName = "Attack";
    public virtual string animationName => _animationName;
    public virtual bool isAttacking => false;
    public virtual bool CanAttack() => true;
    public virtual void Attack() { }


    public virtual void SetTarget(Health target) { }
}