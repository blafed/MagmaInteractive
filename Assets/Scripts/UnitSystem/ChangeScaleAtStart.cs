using UnityEngine;

public class ChangeScaleAtStart : MonoBehaviour
{
    public Vector3 targetScale = Vector3.one;
    public bool multiply;


    private void Start()
    {
        if (multiply)
        {
            transform.localScale = Vector3.Scale(transform.localScale, targetScale);
        }
        else
        {
            transform.localScale = targetScale;
        }
    }
}