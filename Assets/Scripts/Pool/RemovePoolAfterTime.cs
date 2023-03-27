namespace Mend.PoolSystem
{

    using UnityEngine;

    public class RemovePoolAfterTime : MonoBehaviour
    {
        public float time = 1;

        private void OnEnable()
        {
            Invoke("Remove", time);
        }

        private void OnDisable()
        {
            CancelInvoke("Remove");
        }

        private void Remove()
        {
            var p = GetComponent<PoolInstance>();

            if (p)
            {
                PoolManager.instance.Remove(p);
            }
        }
    }
}