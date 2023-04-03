using UnityEngine;

public class Health : MonoBehaviour
{
    public event System.Action<float> onHpChanged;
    public event System.Action<float> onTakeDamage;
    public event System.Action onKilled;

    public Prop hp = new Prop(100);
    public int priority;
    public bool invincible;
    public AudioSource hitAudioSource;
    public AudioSource killAudioSource;

    public bool isKilled { get; private set; }
    public object damageSender { get; private set; }


    public Duration takeDamageTimer { get; } = new Duration();


    private void OnEnable()
    {
        GameLevel.current.healths.Add(this);
    }
    private void OnDisable()
    {
        GameLevel.current.healths.Remove(this);
    }

    public void TakeDamage(float amount, object damageSender)
    {
        if (invincible) return;
        this.damageSender = damageSender;
        onTakeDamage?.Invoke(amount);
        AddHp(-amount);

        takeDamageTimer.StartWithDuration(1);

        if (hitAudioSource != null)
            hitAudioSource.Play();
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

        if (killAudioSource != null)
            killAudioSource.Play();
    }
}