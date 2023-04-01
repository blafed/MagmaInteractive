using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public ProgressBar healthBar;
    public ProgressBar manaBar;
    public DialogText dialogText;


    void Update()
    {
        var hero = Hero.current;
        healthBar.SetAmount(hero.health.hp.ratio);
        manaBar.SetAmount(hero.mana.mana.ratio);
    }


    public void SetDialog(string text)
    {
        dialogText.SetText(text);
    }

}