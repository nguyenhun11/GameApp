using UnityEngine;

public class Bullettrans : BaseBullet
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Kill");
            other.GetComponent<BaseEnemy>().ModifiHealth(-damage);
            Destroy();
        }
    }
    protected override void Destroy()
    {
        PoolingPlayerBullet1.instance.ReturnBullet(gameObject);
    }
}
