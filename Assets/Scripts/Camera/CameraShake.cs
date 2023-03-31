using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;
    public float dampingSpeed = 1.0f;
    Vector3 initialPosition;

    new Transform transform => CameraControl.instance.shakeTransform;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }


    public void Shake(float duration)
    {
        shakeDuration = duration;
    }
    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }



}