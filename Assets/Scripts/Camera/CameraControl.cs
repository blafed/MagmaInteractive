using Codice.Client.Commands.TransformerRule;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class CameraControl : Singleton<CameraControl>
{

    public Vector2 center
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }
    public Vector2 clampingPivot
    {
        get => clamperTransform.localPosition;
        set => clamperTransform.localPosition = value;
    }
    public Vector2 shake
    {
        get => shakeTransform.localPosition;
        set => shakeTransform.localPosition = value;
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

    [SerializeField] public Transform offsetTransform;
    [SerializeField] public Transform shakeTransform;
    [SerializeField] public Transform clamperTransform;
}