using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private int NumberEnemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private int NumberEnemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private int NumberEnemy3;




    private float ScreenHeight;
    private float ScreenWidth;
    [SerializeField] private float minTimeAppear;
    [SerializeField] private float maxTimeAppear;
    private float spawnInterval; // Thời gian giữa các lần xuất hiện
    private float spawnTimer;
    private int EnemyType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScreenHeight = Camera.main.orthographicSize;
        ScreenWidth = ScreenHeight * Camera.main.aspect;
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
            int DirectTypeEnemy1 = Random.Range(1, 5); //1Down 2Up 3Left 4Right
            Vector3 position = Vector3.zero;
            Quaternion rotation = Quaternion.identity;
            if (DirectTypeEnemy1 == 1)
            {
                position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), ScreenHeight + 1);
                rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (DirectTypeEnemy1 == 2)
            {
                position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), -ScreenHeight - 1);
                rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (DirectTypeEnemy1 == 3)
            {
                position = new Vector3(ScreenWidth + 1, Random.Range(-ScreenHeight, ScreenHeight));
                rotation = Quaternion.Euler(0, 0, 90);

            }
            else if (DirectTypeEnemy1 == 4)
            {
                position = new Vector3(-ScreenWidth - 1, Random.Range(-ScreenHeight, ScreenHeight));
                rotation = Quaternion.Euler(0, 0, -90);
            }
            Instantiate(Enemy1, position, rotation);
        }
    }
    private void Enemy2Appear()
    {
        if (player != null && NumberEnemy2 > 0)
        {
            NumberEnemy2--;
            Vector3 position = Vector3.zero;
            int DirectType = Random.Range(1, 5); //1Up 2Down 3Left 4Right
            switch (DirectType)
            {
                case 1:
                    position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), -ScreenHeight - 1);
                    break;
                case 2:
                    position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), ScreenHeight + 1);
                    break;
                case 3:
                    position = new Vector3(ScreenWidth + 1, Random.Range(-ScreenHeight, ScreenHeight));
                    break;
                case 4:
                    position = new Vector3(-ScreenWidth - 1, Random.Range(-ScreenHeight, ScreenHeight));
                    break;
                default:
                    break;
            }
            Vector3 direction = (player.transform.position - position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);
            Instantiate(Enemy2, position, rotation);
        }
    }
    private void Enemy3Appear()
    {
        if (player != null && NumberEnemy3 > 0)
        {
            NumberEnemy3--;
            Vector3 position = Vector3.zero;
            int DirectType = Random.Range(1, 5); //1Up 2Down 3Left 4Right
            switch (DirectType)
            {
                case 1:
                    position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), -ScreenHeight - 1);
                    break;
                case 2:
                    position = new Vector3(Random.Range(-ScreenWidth, ScreenWidth), ScreenHeight + 1);
                    break;
                case 3:
                    position = new Vector3(ScreenWidth + 1, Random.Range(-ScreenHeight, ScreenHeight));
                    break;
                case 4:
                    position = new Vector3(-ScreenWidth - 1, Random.Range(-ScreenHeight, ScreenHeight));
                    break;
                default:
                    break;
            }
            Vector3 direction = (player.transform.position - position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);
            Instantiate(Enemy3, position, rotation);
        }
    }



}
