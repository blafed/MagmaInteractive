namespace Mend
{
    using UnityEngine;

    public class Unit : MonoBehaviour
    {
        public Vector2 position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Health health { get; private set; }
        protected virtual void Awake()
        {
            health = GetComponent<Health>();
        }
    }
}