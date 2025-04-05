



using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesManager : MonoBehaviour
{
    private GameObject player;
    //private PoolingEnemy1 Enemy1;
    //private PoolingEnemy2 Enemy2;
    //private PoolingEnemy3 Enemy3;
    //private PoolingEnemy4 Enemy4;
    //private PoolingEnemy5 Enemy5;
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


//using System.Collections.Generic;
//using UnityEngine;

//public class EnemiesManager : MonoBehaviour
//{
//    [System.Serializable]
//    public class EnemyPoolData
//    {
//        public int enemyType;
//        public PoolingEnemy pool;
//        public int maxSpawn;
//    }

//    [SerializeField] private List<EnemyPoolData> enemyPools;

//    [SerializeField] private float minTimeAppear;
//    [SerializeField] private float maxTimeAppear;

//    private float spawnTimer;
//    private float spawnInterval;
//    private GameObject player;
//    private Dictionary<int, EnemyPoolData> poolDict = new();

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");

//        foreach (var data in enemyPools)
//        {
//            poolDict[data.enemyType] = data;
//        }

//        ResetSpawnTimer();
//    }

//    void Update()
//    {
//        if (player == null) return;

//        spawnTimer += Time.deltaTime;
//        if (spawnTimer >= spawnInterval)
//        {
//            SpawnRandomEnemy();
//            ResetSpawnTimer();
//        }
//    }

//    private void ResetSpawnTimer()
//    {
//        spawnTimer = 0f;
//        spawnInterval = Random.Range(minTimeAppear, maxTimeAppear);
//    }

//    private void SpawnRandomEnemy()
//    {
//        var available = new List<int>();
//        foreach (var kvp in poolDict)
//        {
//            if (kvp.Value.maxSpawn > 0)
//                available.Add(kvp.Key);
//        }

//        if (available.Count == 0) return;

//        int type = available[Random.Range(0, available.Count)];
//        var poolData = poolDict[type];

//        GameObject enemyObj = poolData.pool.GetEnemy();
//        BaseEnemy enemy = enemyObj.GetComponent<BaseEnemy>();
//        enemy.myPool = poolData.pool;

//        Vector3 pos = enemy.firstPositionRandomAppear();
//        Quaternion rot = enemy.firstRotation(pos);
//        enemy.Appear(pos, rot);

//        poolData.maxSpawn--;
//    }
//}