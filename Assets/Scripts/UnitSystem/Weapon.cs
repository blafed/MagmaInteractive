using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{

    [FormerlySerializedAs("animationName")]
    [SerializeField]
    string _animationName = "Attack";
    public virtual string animationName => _animationName;
    public virtual bool isAttacking => false;
    public virtual bool CanAttack() => true;
    public virtual void Attack() { }
}