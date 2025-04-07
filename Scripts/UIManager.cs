using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    #region singleton
    public static UIManager instance;
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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI EnemyLeft;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private TextMeshProUGUI FinalScore;
    [SerializeField] private List<GameObject> Stars;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseButton.SetActive(true);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(GameManager.instance.score.ToString());
        
        EnemyLeft.SetText(EnemiesManager.instance.EnemyLeft.ToString());
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        PauseButton.SetActive(true );
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReStart()
    {
        GameManager.instance.LoadRound1();
    }
    public void Home()
    {
        GameManager.instance.LoadHomeScene();
    }
    public void GameWin()
    {
        FinalScore.SetText(GameManager.instance.score.ToString());
        WinPanel.SetActive(true);
        int count = GameManager.instance.stars;
        for(int i = 0;i< count; i++)
        {
            Stars[i].SetActive(true);
        }
        for(int i = count; i < 5; i++)
        {
            Stars[i].SetActive(false);
        }
    }
    
    



}
