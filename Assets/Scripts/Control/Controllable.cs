using UnityEngine;

namespace MagmaInteractive
{
    [System.Obsolete]
    public class Controllable : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            GameManager.instance.AddControllable(this);
        }
        protected virtual void OnDisable()
        {
            GameManager.instance.AddControllable(this);
        }



        public void OnControl(Controller controller)
        {

        }
    }
}