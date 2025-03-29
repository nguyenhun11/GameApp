using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float BulletSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move();
        AutoDestroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerController>().ModifyHealth(-1);
            player.GetComponent<PlayerController>().TempDeath();
            Destroy(gameObject);
        }
    }
    private void move()
    {
        transform.position += transform.up * BulletSpeed * Time.deltaTime;
    }
    private void AutoDestroy()
    {
        float Height = Camera.main.orthographicSize;
        float Width = Height * Camera.main.aspect;
        if (Mathf.Abs(transform.position.x) - Width > 2 || Mathf.Abs(transform.position.y) - Height > 2)
        {
            Destroy(gameObject);
        }
    }

}
