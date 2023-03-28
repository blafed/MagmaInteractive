using UnityEngine;

public class CameraObject : Singleton<CameraObject>
{
    public Vector2 center
    {
        get => transform.position;
        set => transform.position = value;
    }

    public Vector2 offset
    {
        get => offsetTransform.position;
        set => offsetTransform.position = value;
    }

    [SerializeField] Transform offsetTransform;

}


public class CameraSubScript : MonoBehaviour
{
    public CameraObject cameraObject { get; private set; }
    protected virtual void Awake()
    {
        cameraObject = GetComponentInParent<CameraObject>();
    }
}