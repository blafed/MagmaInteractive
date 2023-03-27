namespace Mend
{
    using UnityEngine;

    public class CameraFollowHero : MonoBehaviour
    {
        public float speed = 1;

        private Transform _heroTransform => Hero.current.transform;
        private Vector3 _offset;


        private void Update()
        {
            var targetPosition = _heroTransform.position + _heroTransform.rotation * _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}