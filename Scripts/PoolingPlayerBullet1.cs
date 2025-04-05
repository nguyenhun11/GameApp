using System.Collections.Generic;
using UnityEngine;

public class PoolingPlayerBullet1 : MonoBehaviour
{
    #region singleton
    public static PoolingPlayerBullet1 instance;
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
    public GameObject Bullet1Prefaps;
    private Queue<GameObject> Bullet1Pool = new Queue<GameObject>();


    public GameObject GetBullet()
    {
        if (Bullet1Pool.Count <= 0)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var b = Instantiate(Bullet1Prefaps);
                b.gameObject.SetActive(false);
                Bullet1Pool.Enqueue(b);
            }
        }
        GameObject bullet = Bullet1Pool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.gameObject.SetActive(false);
        Bullet1Pool.Enqueue(bullet);
    }
}
