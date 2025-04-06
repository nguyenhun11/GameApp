using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float BulletSpeed = 5f;
    public int damage = 1;

    protected void Start()
    {
    }

    protected void Update()
    {
        BulletMove();
        AutoDestroy();
    }

    protected void BulletMove()
    {
        transform.position += transform.up * BulletSpeed * Time.deltaTime;
    }
    protected void AutoDestroy()
    {
        float Height = Camera.main.orthographicSize;
        float Width = Height * Camera.main.aspect;
        if (Mathf.Abs(transform.position.x) - Width >= 1 || Mathf.Abs(transform.position.y) - Height >= 1)
        {
            Destroy();
        }
    }
    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
