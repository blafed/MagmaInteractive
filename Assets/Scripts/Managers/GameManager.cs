using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{


    /// <summary>
    /// called when player should be able to go to the next level
    /// </summary>
    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /// <summary>
    /// finishes the game, called after defeating the boss
    /// </summary>
    public void Win()
    {
        Hero.current.hasWin = true;
        UIManager.instance.ShowWinPopup();
        GameObject.Find("Music").SetActive(false);
        GameObject.Find("Win").GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// called when player dies 
    /// </summary>
    public void GameOver()
    {
        Hero.current.hasWin = true;
    }

    /// <summary>
    ///  restart the current level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayFromStart()
    {
        SceneManager.LoadScene(0);

    }

}