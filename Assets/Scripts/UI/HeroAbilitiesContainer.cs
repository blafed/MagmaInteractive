using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class HeroAbilitiesContainer : MonoBehaviour
{
    [System.Serializable]
    public class AbilityInfo
    {
        public HeroAbilityCode code;
        public Sprite icon;



        public bool CanActivate(Hero hero)
        {
            switch (code)
            {
                case HeroAbilityCode.Dash:
                    return hero.dashAbility.CanDash();
                case HeroAbilityCode.Sprint:
                    return hero.sprintAbility.CanSprint();
                case HeroAbilityCode.DoubleJump:
                    return hero.jumpAbility.CanJump();
                case HeroAbilityCode.ChargedAttack:
                    return hero.chargedWeapon.CanAttack();
                case HeroAbilityCode.UltimateSpell:
                    return hero.ultimateWeapon.CanAttack();
            }
            return false;
        }
        public bool IsActive(Hero hero)
        {
            switch (code)
            {
                case HeroAbilityCode.Dash:
                    return hero.dashAbility.isDashing;
                case HeroAbilityCode.Sprint:
                    return hero.sprintAbility.isSprinting;
                case HeroAbilityCode.DoubleJump:
                    return hero.jumpAbility.isJumping;
                case HeroAbilityCode.ChargedAttack:
                    return hero.chargedWeapon.isAttacking;
                case HeroAbilityCode.UltimateSpell:
                    return hero.ultimateWeapon.isAttacking;
            }
            return false;
        }
        public float GetManaCost(Hero hero)
        {
            switch (code)
            {
                case HeroAbilityCode.Dash:
                    return hero.dashAbility.manaCost;
                case HeroAbilityCode.Sprint:
                    return hero.sprintAbility.manaCost;
                case HeroAbilityCode.DoubleJump:
                    return hero.jumpAbility.secondJumpManaCost;

                case HeroAbilityCode.ChargedAttack:
                    return (hero.chargedWeapon as GenericWeapon).manaCost;
                case HeroAbilityCode.UltimateSpell:
                    return (hero.ultimateWeapon as GenericWeapon).manaCost;
            }
            return 0;
        }
    }
    public List<AbilityInfo> abilities = new List<AbilityInfo>();
    public FlowList<HeroAbilitiesItem> items = new FlowList<HeroAbilitiesItem>();


    private void Start()
    {
        items.iterate(abilities.Count, x =>
        {
            x.component.Setup(abilities[x.iterationIndex]);
        });
    }

}

public enum HeroAbilityCode
{
    None,
    DoubleJump,
    Sprint,
    Dash,
    ChargedAttack,
    UltimateSpell,
}