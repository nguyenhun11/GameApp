using UnityEngine;

public class Enemy4 : BaseEnemy
{
    GameObject player;
    private Quaternion StartRotation;

    
    protected override void Start()
    {
        base.Start();
        StartRotation = transform.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    protected override void Update()
    {
        base.Update();
        RotateToPlayer();
    }
    private void RotateToPlayer()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90);
        //transform.rotation = rotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,200*Time.deltaTime);
    }
    protected override void move()
    {
        float angle = (StartRotation.eulerAngles.z+90)*Mathf.Deg2Rad;
        Vector3 defaultDirection = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        transform.position += defaultDirection.normalized * EnemySpeed * Time.deltaTime;
    }


}
