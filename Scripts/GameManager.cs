using Unity.VisualScripting;
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
    public int maxScore;
    public int stars;
    protected void Start()
    {
        score = 0;
        stars = 0;
        Time.timeScale = 1;
    }
    protected void Update()
    {
        CalculateStars();
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
        
        CalculateStars();
        UIManager.instance.GameWin();
        Time.timeScale = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void CalculateStars()
    {
        if (score >= maxScore * 0.9)
        {
            stars = 5;
        }
        else if (score >= maxScore * 0.75)
        {
            stars = 4;
        }
        else if (score >= maxScore * 0.5)
        {
            stars = 3;
        }
        else if (score >= maxScore * 0.25)
        {
            stars = 2;
        }
        else if (score >= maxScore * 0.1)
        {
            stars = 1;
        }
        else { stars = 0; }
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
