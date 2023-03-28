using UnityEngine;

public class BloodKing : MonoBehaviour
{

    public float sightRange = 10;

    Health health;
    Character character;


    private void Awake()
    {
        health = GetComponent<Health>();
        character = GetComponent<Character>();
    }

}