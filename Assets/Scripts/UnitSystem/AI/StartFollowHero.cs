using UnityEngine;

[DefaultExecutionOrder(1)]
public class StartFollowHero : MonoBehaviour
{
    public float delay = 1;
    private void OnEnable()
    {

        Invoke(nameof(StartFollow), delay);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(StartFollow));
    }

    private void StartFollow()
    {
        var follow = GetComponent<Follow>();
        follow.target = Hero.current.transform;
        follow.enabled = true;
    }
}