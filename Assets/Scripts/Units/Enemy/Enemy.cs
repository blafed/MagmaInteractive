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
    [System.Serializable]
    public class SearchProps
    {
        public float searchRadius = 10f;
        public float searchInterval = 1f;
    }

    public class AttackProps
    {
        public float attackRadius = 1f;
        public float attackInterval = 1f;
    }

    Health health;
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

}