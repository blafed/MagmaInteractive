using UnityEngine;


namespace MagmaInteractive
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T instance { get; private set; }

        protected virtual void Awake()
        {
            instance = (T)this;
        }
    }
}