using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject player;
    [SerializeField] float TimeBetweenShoot = 1f;
    private float timer = 0;
    [SerializeField] private int numberBullet;
    [SerializeField] private float bulletSpeed;
    public Vector3 DefaultDirection;
    public float MoveSpeed = 5f;
    [SerializeField] private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyBullet.GetComponent<EnemyBullet>().BulletSpeed = bulletSpeed;
        DefaultDirection = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotationToPlayer();
        timer += Time.deltaTime;
        if (timer >= TimeBetweenShoot)
        {
            ShootBulletToPlayer();
            timer = 0f;
        }
        AutoDestroy();
    }
    private void Move()
    {
        
        transform.position += DefaultDirection.normalized * MoveSpeed * Time.deltaTime;
    }
    private void ShootBulletToPlayer()
    {
        if (player != null && !player.GetComponent<PlayerController>().IsFainted && numberBullet > 0)
        {
            numberBullet--;
            Vector3 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Instantiate(enemyBullet, transform.position, transform.rotation);
            

        }
    }
    private void RotationToPlayer()
    {
        if(player!= null)
        {
            Vector3 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
        else
        {
            float angle = Mathf.Atan2(DefaultDirection.y, DefaultDirection.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
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
