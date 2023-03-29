using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action<float> onHpChanged;
    public event System.Action<float> onTakeDamage;
    public event System.Action onKilled;

    public Prop hp = new Prop(100);

    public bool isKilled { get; private set; }

    public void TakeDamage(float amount)
    {
        onTakeDamage?.Invoke(amount);
        AddHp(-amount);
    }
    public void ChangeHp(float newValue)
    {
        hp.current = newValue;
        onHpChanged?.Invoke(hp.current);
        if (newValue <= 0)
            Kill();
    }
    public void AddHp(float amount)
    {
        ChangeHp(hp.current + amount);
    }

    public void Kill()
    {
        isKilled = true;
        onKilled?.Invoke();
    }
}