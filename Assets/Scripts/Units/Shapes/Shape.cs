using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Shape : MonoBehaviour
{

    [System.Serializable]
    public class AnimationInfo
    {
        public string name;
        public Vector2 pivot;
        public float duration;
        public int priority;
    }



    public Animator animator { get; private set; }
    public new SpriteRenderer renderer { get; private set; }

    public string animationState { get; set; }
    public string customAnimation { get; set; }
    protected Duration playAnimationDuration = new Duration(1);


    public List<AnimationInfo> animationInfos = new List<AnimationInfo>();

    string oldAnimationState;
    Vector2 originalPivot;

    int animationPirority = 0;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        originalPivot = transform.localPosition;
    }


    void Update()
    {
        oldAnimationState = this.animationState;
        var strNewAnimation = GetNewAnimationState();
        if (!string.IsNullOrEmpty(strNewAnimation))
            this.animationState = strNewAnimation;

        var newPriority = 0;

        foreach (var x in animationInfos)
        {
            if (x.name == animationState)
                newPriority = x.priority;
        }



        if (playAnimationDuration.isDone || newPriority >= animationPirority)
        {
            if (!IsAnimationPlaying(animationState))
            {
                SetAnimation(animationState);

                transform.localPosition = originalPivot;
                animationPirority = 0;
                foreach (var x in animationInfos)
                {
                    if (x.name == animationState)
                    {
                        transform.localPosition = originalPivot + x.pivot;
                        playAnimationDuration.StartWithDuration(x.duration);
                        animationPirority = x.priority;
                    }
                }
            }
        }
    }
    protected virtual string GetNewAnimationState()
    {
        return "";
    }

    public bool IsAnimationPlaying(string animationName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }
    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}