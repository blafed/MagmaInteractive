
using UnityEngine;

namespace Mend
{
    public class Health : MonoBehaviour
    {
        [Range(0, 1)]
        public float hp = 1;
        [Min(1)]
        public float maxHp = 100;


        public bool isKilled { get; private set; }


        public void TakeDamage(float damage, object sender)
        {
            if (isKilled)
                return;
            damage /= maxHp;

            ChangeHp(hp - damage);
        }

        public void Kill()
        {
            if (isKilled)
                return;
            isKilled = true;
        }
        public void ChangeHp(float newHp)
        {
            if (isKilled)
                return;
            hp = Mathf.Clamp01(newHp);
            if (newHp <= 0)
                Kill();
        }
    }
}