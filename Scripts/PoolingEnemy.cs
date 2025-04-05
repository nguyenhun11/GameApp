using System.Collections.Generic;
using UnityEngine;

public class PoolingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> Pool = new Queue<GameObject>();

    

    public GameObject GetEnemy()
    {
        if (Pool.Count <= 0)
        {
            
            for (int i = 0; i < poolSize; i++)
            {
                GameObject b = Instantiate(Enemy);
                b.gameObject.SetActive(false);
                Pool.Enqueue(b);
            }
        }
        GameObject enemy = Pool.Dequeue();
        enemy.gameObject.SetActive(true);
        return enemy;

    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        Pool.Enqueue(enemy);
    }

   
}
