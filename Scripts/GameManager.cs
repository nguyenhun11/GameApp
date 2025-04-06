using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion 

    public int score;

    protected void Start()
    {
        score = 0;
        Time.timeScale = 1;
    }
    public void AddScore(int a)
    {
        score += a;
        Debug.Log("Add " + a + " score");
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        UIManager.instance.GameOver();
    }
    public void GameWin()
    {
        Time.timeScale = 0;
        UIManager.instance.GameWin();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadRound1()
    {
        SceneManager.LoadScene("Round1");
        Time.timeScale = 1;
    }
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 0;
    }
    
}
