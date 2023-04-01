using UnityEngine;
using UnityEngine.UI;
public class DialogText : MonoBehaviour
{
    public float letterRate = 15;
    public float stayDuration = 2;
    Duration stayDurationTimer = new Duration();
    Text text;


    string targetText;


    Duration awaiter = new Duration();


    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "";
    }



    private void FixedUpdate()
    {

    }



    public void SetText(string text)
    {
        this.text.gameObject.SetActive(true);
        stayDurationTimer.StartWithDuration(stayDuration + text.Length / (float)letterRate);
        targetText = text;
    }


    void Update()
    {
        var str = text.text;
        if (str.Length < targetText.Length && awaiter.isDone)
        {
            str += targetText[str.Length];
            text.text = str;
            awaiter.StartWithDuration(1 / letterRate);
        }
    }
}