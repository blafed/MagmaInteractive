using UnityEngine;
public class Weapon : MonoBehaviour
{

    public event System.Action onAttack;

    public Unit owner { get; private set; }
    public virtual bool isAttacking { get; }
    public float reload = 1;
    public float damage = 10;
    [SerializeField] AudioSource attackAudio;


    protected float reloadTimer;

    protected virtual void Awake()
    {
        owner = GetComponentInParent<Unit>();
    }
    protected virtual void Start() { }

    public virtual bool CanAttack()
    {
        return Time.time > reloadTimer + reload;
    }
    public virtual void Attack()
    {
        reloadTimer = Time.time;
        onAttack?.Invoke();
        if (attackAudio)
            attackAudio.Play();
    }

}