using System.Collections;
using UnityEngine;

public class NpcAction : MonoBehaviour
{
    public bool isRunning { get; set; }
    public virtual void Run()
    {
        isRunning = true;
    }
}
