using UnityEngine;

public class TrashMonster : MonoBehaviour
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Die,

    }
    Sight sight;
    State state;
    Shape shape;
    TargetedWeapon weapon;
    Health health;

    private void Awake()
    {
        shape = GetComponentInChildren<Shape>();
        sight = GetComponent<Sight>();
        weapon = GetComponentInChildren<TargetedWeapon>();
        health = GetComponent<Health>();



        sight.onTargetEnter += OnTargetEnter;
        health.onKilled += () =>
        {
            foreach (var x in GetComponentsInChildren<Collider2D>())
            {
                x.enabled = false;
            }
            state = State.Die;
            Destroy(gameObject, 2);
        };
    }

    private void OnTargetEnter(GameObject target)
    {
        if (health.isKilled)
            return;
        state = State.Run;
        weapon.target = target.GetComponentInParent<Health>();

    }


    private void Update()
    {
        shape.animationState = state.ToString();
    }

    private void FixedUpdate()
    {
        if (health.isKilled)
            return;
        if (weapon.CanAttack())
        {
            weapon.Attack();
        }
    }


}