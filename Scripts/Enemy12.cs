using NUnit.Framework.Constraints;
using UnityEngine;

public class Enemy12 : MonoBehaviour
{
    [SerializeField] private float EnemySpeed = 5f;
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
    private void move()
    {
        transform.position += transform.up * EnemySpeed * Time.deltaTime;
    }
    private void AutoDestroy()
    {
        float Height = Camera.main.orthographicSize;
        float Width = Height * Camera.main.aspect;
        if(Mathf.Abs(transform.position.x) - Width > 2 || Mathf.Abs(transform.position.y) - Height > 2)
        {
            Destroy(gameObject);
        }
    }
}
