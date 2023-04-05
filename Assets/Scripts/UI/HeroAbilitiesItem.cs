using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HeroAbilitiesItem : MonoBehaviour
{
    public Image image;
    public Image cover;

    public Color normalColor = Color.white;
    public Color activeColor = new Color(1, 1, 1, .3f);
    public Color disabledColor;

    HeroAbilitiesContainer.AbilityInfo abilityInfo;


    float activePulse;
    private void Update()
    {
        if (abilityInfo.IsActive(Hero.current))
        {
            activePulse += Time.deltaTime * 2;
            cover.color = Color.Lerp(normalColor, activeColor, Mathf.PingPong(activePulse, .5f));
        }
        else if (!abilityInfo.CanActivate(Hero.current))
        {
            cover.color = disabledColor;
        }
        else
        {
            cover.color = Color.clear;
        }
    }



    public void Setup(HeroAbilitiesContainer.AbilityInfo abilityInfo)
    {
        this.abilityInfo = abilityInfo;
        image.sprite = abilityInfo.icon;
    }



}

