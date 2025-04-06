using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBullet : BaseBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().ModifyHealth(-damage);
            //collision.GetComponent<PlayerHealth>().TempDeath();
            Destroy();
        }
    }
    protected override void Destroy()
    {
        PoolingEnemyBullet1.instance.ReturnBullet(gameObject);
    }
}
