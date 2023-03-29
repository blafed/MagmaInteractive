using UnityEngine;

public class SkeletonWarrior : MonoBehaviour
{
    public float damage = 25;

    public float range = 1;

    [SerializeField] AudioSource attackAudio;
    [SerializeField] GameObject killEffect;



    private void FixedUpdate()
    {

    }
}