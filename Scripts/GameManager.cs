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
    public Scene Round;

    public int score;
    [SerializeField] private GameObject GameOverPanel; 

    protected void Start()
    {
        score = 0;
        GameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
    }
    public void AddScore(int a)
    {
        score += a;
        Debug.Log("Add " + a + " score");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("Round1");
        Time.timeScale = 1;
    }
}
