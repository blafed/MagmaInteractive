using UnityEngine;

public class CameraObject : Singleton<CameraObject>
{
    public Vector2 center
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }
    public Vector2 clampingPivot
    {
        get => clampingPivotTransform.localPosition;
        set => clampingPivotTransform.localPosition = value;
    }

    public Vector2 offset
    {
        get => offsetTransform.localPosition;
        set => offsetTransform.localPosition = value;
    }


    public new Camera camera { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        camera = GetComponentInChildren<Camera>();
    }

    [SerializeField] Transform offsetTransform;
    [SerializeField] Transform clampingPivotTransform;

}


public class CameraSubScript : MonoBehaviour
{
    public CameraObject cameraObject { get; private set; }
    protected virtual void Awake()
    {
        cameraObject = GetComponentInParent<CameraObject>();
    }
}