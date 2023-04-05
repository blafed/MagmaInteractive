using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Retry()
    {
        GameManager.instance.RestartLevel();
    }
}