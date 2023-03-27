namespace Mend.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class ProgressBar : MonoBehaviour
    {

        Image rectFill;


        float lastFill;

        private void Awake()
        {
            rectFill = transform.GetChild(0).GetComponent<Image>();
        }

        public void SetFill(float fill, float duration = .5f)
        {
            if (lastFill == fill)
                return;
            StartCoroutine(AnimateFill(fill, duration));
            lastFill = fill;
        }

        System.Collections.IEnumerator AnimateFill(float fill, float duration)
        {
            float startFill = rectFill.fillAmount;
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                rectFill.fillAmount = Mathf.Lerp(startFill, fill, t * t);
                yield return null;
            }
        }
    }
}