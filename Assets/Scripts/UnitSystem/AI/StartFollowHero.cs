using UnityEngine;

public class StartFollowHero : MonoBehaviour
{
    private void OnEnable()
    {
        var follow = GetComponent<Follow>();
        follow.target = Hero.current.transform;
        follow.enabled = true;
    }
}