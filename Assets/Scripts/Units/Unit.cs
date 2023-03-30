using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public Animator animator { get;private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    protected virtual void Awake()
    {
        animator =GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
