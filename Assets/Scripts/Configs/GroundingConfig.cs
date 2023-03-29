using UnityEngine;

[CreateAssetMenu(fileName = "GroundingConfig", menuName = "Config/Grounding", order = 0)]
public class GroundingConfig : Config<GroundingConfig>
{
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
}