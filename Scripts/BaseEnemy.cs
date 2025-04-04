using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    protected int damage = 1;
    public float EnemySpeed = 2f;


    ///////////////////////////


    virtual protected void Start()
    {
        
    }

    virtual protected void Update()
    {
        move();
        AutoDestroy();
    }

    protected void AutoDestroy()
    {
        float Height = Camera.main.orthographicSize;
        float Width = Height * Camera.main.aspect;
        if (Mathf.Abs(transform.position.x) - Width > 2 || Mathf.Abs(transform.position.y) - Height > 2)
        {
            Destroy(gameObject);
        }
    }

    virtual protected void move()
    {
        transform.position += transform.up * EnemySpeed * Time.deltaTime;
    }

    virtual protected Vector3 firstPositionRandomAppear()
    {
        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = Camera.main.aspect * screenHeight;
        Vector3 position = Vector3.zero;
        int type = Random.Range(1, 5);

        switch (type)
        {
            case 1:
                position = new Vector3(Random.Range(-screenWidth, screenWidth), screenHeight + 1);
                break;
            case 2:
                position = new Vector3(Random.Range(-screenWidth, screenWidth), -screenHeight - 1);
                break;
            case 3:
                position = new Vector3(screenWidth + 1, Random.Range(-screenHeight, screenHeight));
                break;
            case 4:
                position = new Vector3(-screenWidth - 1, Random.Range(-screenHeight, screenHeight));
                break;
        }
        return position;
    }

    virtual protected Quaternion firstRotation(Vector3 spawnPosition)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - spawnPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, angle - 90);
    }

    virtual public void Appear(GameObject prefapEnemy)
    {
        Vector3 position = firstPositionRandomAppear();
        Quaternion rotation = firstRotation(position);
        Instantiate(prefapEnemy, position, rotation);
    }

    

}
