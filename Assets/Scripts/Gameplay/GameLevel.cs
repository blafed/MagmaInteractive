using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GameLevel : MonoBehaviour
{
    [Min(1)]
    public int levelNumber = 1;
    public static GameLevel current { get; private set; }

    public event System.Action onGameOver;

    public GameOverResult gameOverResult { get; private set; }

    public List<Health> healths = new List<Health>();
    public List<Door> doors = new List<Door>();
    public List<Key> keys = new List<Key>();
    // public List<SpellTarget> spellTargets = new List<SpellTarget>();
    private void Awake()
    {
        current = this;
    }



    // public void Win()
    // {
    //     gameOverResult = GameOverResult.Win;
    //     onGameOver?.Invoke();
    // }
    // public void Lose()
    // {
    //     gameOverResult = GameOverResult.Lose;
    //     onGameOver?.Invoke();
    // }
}


public enum GameOverResult
{
    Unset,
    Win,
    Lose,

}