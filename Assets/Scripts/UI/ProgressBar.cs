using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    Image fillImage;
    float targetAmount;

    private void Awake()
    {
        fillImage = transform.GetChild(0).GetComponent<Image>();
    }


    private void Update()
    {
        //animate fill of fillImage
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetAmount, Time.deltaTime * 5);
    }
    public void SetAmount(float amount)
    {
        targetAmount = amount;
    }
}