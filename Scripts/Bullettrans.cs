using UnityEngine;

public class Bullettrans : MonoBehaviour
{
    public float BulletSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
        
    }
    private void BulletMove()
    {
        // Move the bullet in the direction it's facing (transform.up for 2D)
        transform.position += transform.up * BulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Kill");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
