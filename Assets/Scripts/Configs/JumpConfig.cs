using UnityEngine;

[CreateAssetMenu(fileName = "JumpConfig", menuName = "Config/Jump", order = 0)]
public class JumpConfig : Config<JumpConfig>
{
    public float flushInterval = .5f;
}