namespace Mend
{
    using UnityEngine;

    public class RemoveAfterTime : MonoBehaviour
    {
        public float time = 1;
        private float timer;

        private void Start()
        {
            timer = Time.time;
        }

        private void FixedUpdate()
        {
            if (Time.time > timer + time)
            {
                Destroy(gameObject);
            }
        }
    }
}