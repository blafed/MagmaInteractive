namespace Mend
{
    using UnityEngine;

    public class WeaponAssignAnimationState : MonoBehaviour
    {
        public HeroAnimationState heroAnimationState;
        Hero hero;
        Weapon weapon;
        private void Awake()
        {
            hero = GetComponentInParent<Hero>();
            weapon = GetComponent<Weapon>();
        }
        private void Start()
        {
            weapon.onAttack += AssignAnimationState;
        }


        private void FixedUpdate()
        {
            if (!weapon.enabled)
                return;
            if (weapon.isAttacking)
            {
                hero.shape.weaponAnimationState = heroAnimationState;
            }
            else
            {
                hero.shape.weaponAnimationState = HeroAnimationState.Unset;
            }
        }
        private void AssignAnimationState()
        {
            hero.shape.weaponAnimationState = heroAnimationState;
        }
    }
}