using UnityEngine;
namespace Mend
{
    public class Power : MonoBehaviour
    {
        [Range(0, 1)]
        public float power = 1;
        [Tooltip("The rate at which power regenerates per minute")]
        public float regenRate = 1;


        private void FixedUpdate()
        {
            power += regenRate * Time.fixedDeltaTime / 60;
            power = Mathf.Clamp01(power);
        }



        public void UsePower(float amount)
        {
            power -= amount;
            power = Mathf.Clamp01(power);
        }

    }
}