using System.Collections.Generic;
using UnityEngine;
namespace MagmaInteractive
{

    public class GameManager : Singleton<GameManager>
    {
        public List<Controllable> controllables = new List<Controllable>();
        public void AddControllable(Controllable controllable)
        {
            controllables.Add(controllable);
        }
        public void RemoveControllable(Controllable controllable)
        {
            controllables.Remove(controllable);
        }
    }
}