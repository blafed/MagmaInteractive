using UnityEngine;

public class Config<T> : ScriptableObject where T : Config<T>
{
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<T>(typeof(T).Name);
            }
            return _instance;
        }
    }
    static T _instance;
}