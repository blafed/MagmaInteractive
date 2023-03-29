using UnityEngine;
using UnityEngine;

[System.Serializable]
public class CreateEffectOptions
{
    public GameObject prefab;
    public bool parent;



    public void Create(Transform target)
    {
        GameObject effect = GameObject.Instantiate(prefab, target.position, target.rotation);
        if (parent)
        {
            effect.transform.SetParent(target);
        }
    }


    public static implicit operator bool(CreateEffectOptions options)
    {
        return options != null && options.prefab != null;
    }
}