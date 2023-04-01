// using System.Collections.Generic;
// using UnityEngine;

// public class TweenManager : Singleton<TweenManager>
// {
//     public List<Tween> tweens = new List<Tween>();



//     void Update()
//     {
//         for (int i = 0; i < tweens.Count; i++)
//         {
//             var t = tweens[i];
//             t.timeSinceStart += Time.deltaTime;
//             t.Update(t.Evaluate(t.timeSinceStart));

//             if (t.autoRemove && t.Evaluate(t.timeSinceStart) >= 1)
//             {
//                 tweens.RemoveAt(i);
//                 i--;
//             }
//         }
//     }
// }