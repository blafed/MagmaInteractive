using Mend.UI;
using UnityEngine;

namespace Mend
{
    public class HeroUIManager : Singleton<HeroUIManager>
    {
        [SerializeField] ProgressBar healthBar;
        [SerializeField] ProgressBar powerBar;



        private void Update()
        {
            healthBar.SetFill(Hero.current.health.hp);
            powerBar.SetFill(Hero.current.power.power);
        }
    }
}