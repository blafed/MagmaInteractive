// using System;
// using UnityEngine;

// public abstract class Tween
// {
//     public float timeSinceStart { get; set; }
//     public virtual bool autoRemove => true;

//     public Tween()
//     {
//         TweenManager.instance.tweens.Add(this);
//     }

//     public virtual float Evaluate(float t)
//     {
//         return Mathf.Clamp01(t);
//     }
//     public virtual void Update(float p)
//     {
//     }


//     protected virtual void OnStart() { }

//     class Duration : Tween
//     {
//         public float duration = 1;


//         public override float Evaluate(float f)
//         {
//             return Mathf.Clamp01(f / duration);
//         }
//     }


//     class CombosedTween : Tween
//     {
//         public Tween evaluator;
//         public Tween updater;

//         public override float Evaluate(float t)
//         {
//             return evaluator.Evaluate(t);
//         }

//         public override void Update(float p)
//         {
//             updater.Update(p);
//         }
//     }

//     class ValueTween : Tween
//     {
//         public Func<float> getter;
//         public Action<float> setter;
//         public float to;
//         public float from;

//         public ValueTween()
//         {
//         }

//         public override void Update(float p)
//         {
//             setter(Mathf.Lerp(from, to, p));
//         }
//     }
// }
