using System.Runtime.ExceptionServices;
using UnityEngine;

public class SprintAbility : MonoBehaviour
{
    public float boost = 2f;
    [SerializeField]
    GameObject effect;
    AudioSource audioSource;
    public float manaConsumption = 300;
    Hero hero;

    public bool isSprinting { get; private set; }


    private void Awake()
    {
        hero = GetComponentInParent<Hero>();
        audioSource = GetComponent<AudioSource>();

    }



    public void SetSprinting(bool value)
    {
        isSprinting = value;
    }
    public bool CanSprint()
    {
        return hero.grounding.isGrounded && hero.mana.mana.current >= 1;
    }




    private void FixedUpdate()
    {
        if (isSprinting)
        {
            hero.movement.speedFactor = boost;
            if (!audioSource.isPlaying)
                audioSource.Play();
            hero.mana.mana.current -= manaConsumption * Time.fixedDeltaTime / 60;
        }
        else
        {
            hero.movement.speedFactor = 1;
            if (audioSource.isPlaying)
                audioSource.Stop();
        }

        effect.SetActive(isSprinting);
    }
}