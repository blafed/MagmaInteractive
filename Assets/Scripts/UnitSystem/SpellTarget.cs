using UnityEngine;

[System.Obsolete("Use Health instead")]
public class SpellTarget : MonoBehaviour
{
    public int priority;
    public Health health { get; private set; }
    public Rect rect => Helper.ScaleRect(_localRect, transform);
    Rect _localRect = new Rect(-0.5f, -0.5f, 1, 1);
    private void Awake()
    {
        health = GetComponentInParent<Health>();
    }
    // private void OnEnable()
    // {
    //     GameLevel.current.spellTargets.Add(this);
    // }
    // private void OnDisable()
    // {
    //     GameLevel.current.spellTargets.Remove(this);
    // }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(rect.center, rect.size);
    }
}