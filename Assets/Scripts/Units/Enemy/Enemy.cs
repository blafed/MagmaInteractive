using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public enum State
    {
        Idle,
        Patrol,
        Attack,
        Follow,
        Die
    }

    public Health health { get; private set; }
    Shape shape;
    Weapon weapon;
    Health target;

    private void Awake()
    {
        health = GetComponent<Health>();
        shape = GetComponentInChildren<Shape>();
        weapon = GetComponentInChildren<Weapon>();
    }

    void SearchForTarget() { }
    void AttackTarget() { }
    void FollowTarget() { }
    void Patrol() { }
    void Die() { }


    protected virtual void Cycle()
    {

    }

}