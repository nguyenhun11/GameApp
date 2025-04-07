



using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesManager : MonoBehaviour
{
    #region singleton
    public static EnemiesManager instance;
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

    private GameObject player;
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private int NumberEnemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private int NumberEnemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private int NumberEnemy3;
    [SerializeField] private GameObject Enemy4;
    [SerializeField] private int NumberEnemy4;
    [SerializeField] private GameObject Enemy5;
    [SerializeField] private int NumberEnemy5;
    public int EnemyLeft;

    [SerializeField] private float minTimeAppear;
    [SerializeField] private float maxTimeAppear;
    private float spawnInterval; // Thời gian giữa các lần xuất hiện
    private float spawnTimer;
    private int EnemyType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
        spawnInterval = Random.Range(minTimeAppear, maxTimeAppear);
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyLeft = NumberEnemy1 + NumberEnemy2 + NumberEnemy3 + NumberEnemy4 + NumberEnemy5;
        GameManager.instance.maxScore = NumberEnemy1 * Enemy1.GetComponent<BaseEnemy>().damage
            + NumberEnemy2 * Enemy2.GetComponent<BaseEnemy>().damage
            + NumberEnemy3 * Enemy3.GetComponent<BaseEnemy>().damage
            + NumberEnemy4 * Enemy4.GetComponent<BaseEnemy>().damage
            + NumberEnemy5 * Enemy5.GetComponent<BaseEnemy>().damage;
        ChooseEnemyType();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAppear();
    }
    private void ChooseEnemyType()
    {
        List<int> availableEnemyTypes = new List<int>();
        if (NumberEnemy1 > 0)
        {
            availableEnemyTypes.Add(1);
        }
        if (NumberEnemy2 > 0)
        {
            availableEnemyTypes.Add(2);
        }
        if (NumberEnemy3 > 0)
        {
            availableEnemyTypes.Add(3);
        }
        if (NumberEnemy4 > 0)
        {
            availableEnemyTypes.Add(4);
        }
        if (NumberEnemy5 > 0)
        {
            availableEnemyTypes.Add(5);
        }
        if (availableEnemyTypes.Count > 0)
        {
            EnemyType = availableEnemyTypes[Random.Range(0, availableEnemyTypes.Count)];
        }
    }
    private void EnemyAppear()
    {
        if (player != null)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                Debug.Log(EnemyType);
                switch (EnemyType)
                {
                    case 1:
                        Enemy1Appear();
                        break;
                    case 2:
                        Enemy2Appear();
                        break;
                    case 3:
                        Enemy3Appear();
                        break;
                    case 4:
                        Enemy4Appear();
                        break;
                    case 5:
                        Enemy5Appear();
                        break;
                }
                spawnTimer = 0f; // Đặt lại bộ đếm sau mỗi lần xuất hiện
                spawnInterval = Random.Range(minTimeAppear, maxTimeAppear);
                ChooseEnemyType();
            }
        }
    }
    private void Enemy1Appear()
    {
        if (NumberEnemy1 > 0)
        {
            NumberEnemy1--;
            Enemy1.GetComponent<Enemy1>().Appear(Enemy1);
        }
    }
    private void Enemy2Appear()
    {
        if (player != null && NumberEnemy2 > 0)
        {
            NumberEnemy2--;
            Enemy2.GetComponent<Enemy2>().Appear(Enemy2);
        }
    }
    private void Enemy3Appear()
    {
        if (player != null && NumberEnemy3 > 0)
        {
            NumberEnemy3--;
            Enemy3.GetComponent<Enemy3>().Appear(Enemy3);
        }
    }
    private void Enemy4Appear()
    {
        if (player != null && NumberEnemy4 > 0)
        {
            NumberEnemy4--;
            Enemy4.GetComponent<Enemy4>().Appear(Enemy4);
        }
    }
    private void Enemy5Appear()
    {
        if (player != null && NumberEnemy5 > 0)
        {
            NumberEnemy5--;
            Enemy5.GetComponent<Enemy5>().Appear(Enemy5);
        }
    }
    


}


