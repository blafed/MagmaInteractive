using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public ProgressBar healthBar;
    public ProgressBar manaBar;
    public ProgressBar bossBar;
    public DialogText dialogText;

    [SerializeField] GameOverPanel gameOverPanel;
    [SerializeField] GameObject bossUI;


    void Start()
    {
        Hero.current.health.onKilled += () => OnHeroKilled();
    }

    void OnHeroKilled()
    {
        gameOverPanel.Show();
    }
    void Update()
    {
        var hero = Hero.current;
        bossUI.SetActive(Boss.current);
        healthBar.SetAmount(hero.health.hp.ratio);
        manaBar.SetAmount(hero.mana.mana.ratio);
        if (Boss.current)
        {
            bossBar.SetAmount(Boss.current.health.hp.ratio);
        }
    }


    public void SetDialog(string text)
    {
        dialogText.SetText(text);
    }

}