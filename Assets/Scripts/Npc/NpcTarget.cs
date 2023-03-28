using Unity.VisualScripting;
using UnityEngine;

public class NpcTarget : MonoBehaviour
{
    public static NpcTarget current;
    public Unit unit { get; private set; }
    public Hero hero => unit as Hero;
    private void Awake()
    {
        unit = GetComponent<Unit>();
    }
    void OnEnable()
    {
        if (!current)
            current = this;
    }

    void OnDisable()
    {
        if (current == this)
            current = null;
    }






}