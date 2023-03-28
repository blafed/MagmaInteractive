using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroUIManager : Singleton<HeroUIManager>
{
    public float showInfoRate = 10;
    [SerializeField] ProgressBar healthBar;
    [SerializeField] ProgressBar powerBar;

    [SerializeField] Text infoText;



    private void Update()
    {
        healthBar.SetFill(Hero.current.health.hp);
        powerBar.SetFill(Hero.current.power.power);
    }





    public void ShowInfo(string text)
    {
        infoText.text = text;
        if (showInfoCurrentCoroutine != null)
        {
            StopCoroutine(showInfoCurrentCoroutine);
        }
        showInfoCurrentCoroutine = ShowInfoCoroutine(text, .5f);
    }
    IEnumerator showInfoCurrentCoroutine;

    IEnumerator ShowInfoCoroutine(string text, float duration)
    {
        var str = "";
        for (int i = 0; i < text.Length; i++)
        {
            str += text[i];
            infoText.text = str;
            yield return new WaitForSeconds(1 / showInfoRate);
        }
    }
}