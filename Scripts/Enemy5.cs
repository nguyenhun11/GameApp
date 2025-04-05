using UnityEngine;

public class Enemy5 : BaseEnemy
{
    private Vector3 StartDirection;

    protected override void Start()
    {
        base.Start();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            StartDirection = player.transform.position - transform.position;
        }
        else
        {
            StartDirection = Vector3.zero - transform.position;
        }
        StartDirection.Normalize();
    }
    public override Quaternion firstRotation(Vector3 spawnPosition)
    {
        return Quaternion.identity;
    }
    protected override void move()
    {
        transform.position += StartDirection * EnemySpeed * Time.deltaTime;
    }
}
