using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameLevel : MonoBehaviour
{
    public static GameLevel current { get; private set; }

    public List<SpellTarget> spellTargets = new List<SpellTarget>();
    private void Awake()
    {
        current = this;
    }
}