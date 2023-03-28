
using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action onKilled;
    public event System.Action<float> onHpChanged;
    public event System.Action<float> onTakeDamage;
    public Unit unit { get; private set; }

    [Range(0, 1)]
    public float hp = 1;
    [Min(1)]
    public float maxHp = 100;



    public float lastTakeDamageTime { get; private set; }



    public bool isKilled { get; private set; }

    private void Awake()
    {
        unit = GetComponentInParent<Unit>();
    }


    public void TakeDamage(float damage, object sender)
    {
        if (isKilled)
            return;
        damage /= maxHp;
        lastTakeDamageTime = Time.time;
        ChangeHp(hp - damage);
        onTakeDamage?.Invoke(damage);
    }

    public void AddHp(float amount)
    {
        if (isKilled)
            return;
        amount /= maxHp;
        ChangeHp(hp + amount);
        onHpChanged?.Invoke(amount);
    }

    public void Kill()
    {
        if (isKilled)
            return;
        isKilled = true;
        onKilled?.Invoke();
    }
    public void ChangeHp(float newHp)
    {
        if (isKilled)
            return;
        hp = Mathf.Clamp01(newHp);
        if (newHp <= 0)
            Kill();
    }
}